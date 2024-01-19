using Microsoft.EntityFrameworkCore;
using TransferBase.Application.CustomModels;
using TransferBase.Application.Database;
using TransferBase.Application.Models;
using TransferBase.Application.Services.General;

namespace TransferBase.Application.Services.FixData
{
    /*Service to fetch transfers*/
    public class TransfersService
    {
        private readonly DatabaseContext _db;

        /*initialize the database instance*/
        public TransfersService(DatabaseContext db)
        {
            _db = db;
        }

        /* return transferprice of all transfers exists in db */
        public List<TransferPrice> GetTransferPrices()
        {
            return _db.TransferPrices.ToList();
        }

        /* return a transferprice of specific player*/
        public List<TransferPrice> GetTransferPricesOfPlayer(string player)
        {
            if (player == null)
                return null;

            return _db.TransferPrices.Where(a => a.PlayerName!.Trim() == player.Trim() && a.TransferMovement == "in").OrderBy(a => a.Year).ToList();
        }

        /* find a transfer and update the value of transfersuccess field */
        public void UpdateTransferSuccess(Transfer transfer, double transferSuccess)
        {
            var findTransfer = _db.Transfers.Find(transfer.Id);

            if (findTransfer != null)
            {
                findTransfer.TransferSuccess = transferSuccess;

                _db.Transfers.Update(findTransfer);
                _db.SaveChanges();
            }
        }

        public void UpdateTransfer(Transfer transfer, int transferFee)
        {
            var findTransfer = _db.Transfers.Find(transfer.Id);

            if (findTransfer != null)
            {
                findTransfer.TransferPriceFuture = transferFee;

                _db.Transfers.Update(findTransfer);
                _db.SaveChanges();
            }

        }

        /* search for specific transfer */
        public Transfer SearchForSameTransferDetails(string playerName, string clubFrom, string clubTo)
        {
            if (playerName == null || clubFrom == null || clubTo == null)
                return null;

            return _db.Transfers.Where(a => a.PlayerName == playerName && a.ClubFrom.Contains(clubFrom) && a.ClubTo.Contains(clubTo)).FirstOrDefault()!;
        }

        /* return the previous team / transfer to team of a specific player */
        public Transfer GetPreviousTransfer(string playerName, int season)
        {
            int i = 1;
            var previousTransfer = GetTransfer(playerName, season);

            while (previousTransfer == null)
            {
                previousTransfer = GetTransfer(playerName, season - i);
                i++;
            }

            return previousTransfer;
        }

        /* return a transfer of a specific player in a specific season */
        public Transfer GetTransfer(string playerName, int season)
        {
            return _db.Transfers.Where(a => a.PlayerName == playerName && a.Season == season).FirstOrDefault()!;
        }

        /* return all transfers */
        public List<Transfer> GetTransfers()
        {
            return _db.Transfers.ToList();
        }

        /* return duplicate transfers of a specific player */
        public List<Transfer> GetDuplicateTransfer(int season, string name)
        {
            if (season <= 0 && name == null)
                return null;

            return _db.Transfers.Where(a => a.Season == season && a.PlayerName == name).ToList();
        }

        /*  return transfers depend on position */
        public List<Transfer> GetTransfersByPosition(string position)
        {
            return _db.Transfers.Where(a => a.PlayerPosition == position).ToList();
        }

        /* return transfers in specific format, filled information like playerId, Name, ClubId, Goals, Assists, YC, RC, MP, Season */
        public List<PlayerStatisticsMod> FetchTransfers()
        {
            return (from ap in _db.Appearances
                    join p in _db.Players on ap.PlayerId equals p.Id
                    where ap.Season >= 2017 && ap.Season <= 2021
                    group new { ap, p } by new { ap.PlayerId, p.Name, ap.ClubId, ap.Season, ap.LastAppearance } into grouped
                    orderby grouped.Key.PlayerId, grouped.Key.Season, grouped.Key.LastAppearance
                    select new PlayerStatisticsMod
                    {
                        PlayerId = grouped.Key.PlayerId,
                        Name = grouped.Key.Name,
                        PlayerClubId = grouped.Key.ClubId,
                        Goals = grouped.Sum(x => x.ap.Goals),
                        Assists = grouped.Sum(x => x.ap.Assists),
                        YellowCards = grouped.Sum(x => x.ap.YellowCards),
                        RedCards = grouped.Sum(x => x.ap.RedCards),
                        MinutesPlayed = grouped.Sum(x => x.ap.MinutesPlayed),
                        Season = grouped.Key.Season
                    }).ToList();
        }

        /* return previous transfers of specific players from one season to another */
        public List<int> FetchTransfersForSpecificPlayer(int playerId, int toSeason)
        {
            var result = from ap in _db.Appearances
                         where ap.PlayerId == playerId && ap.Season >= 2017 && ap.Season <= toSeason
                         group ap.ClubId by ap.ClubId into grouped
                         select grouped.Key;

            return result.ToList();
        }

        /* check if a player played in bigger competitions during his career */
        public bool ComparePlayerCompetitions(int playerId, int toClubId, int season)
        {
            if (playerId <= 0 || toClubId <= 0 || season <=0) return false;

            var list = FetchTransfersForSpecificPlayer(playerId, season);

            if (list != null)
            {
                ClubsService clubsService = new(_db);
                CompetitionsService competitionsService = new CompetitionsService(_db);

                var currentClub = clubsService.GetClubByClubId(toClubId);

                foreach (var item in list)
                {
                    var previousClub = clubsService.GetClubByClubId(item);
                    if (previousClub != null && currentClub != null)
                    {
                        Competition previousClubCompetition = competitionsService.GetCompetitionById(previousClub.DomesticCompetitionId!);
                        Competition currentClubCompetition = competitionsService.GetCompetitionById(currentClub.DomesticCompetitionId!);

                        if (previousClubCompetition != null && currentClubCompetition != null)
                        {
                            if (previousClubCompetition.CompetitionRanking > currentClubCompetition.CompetitionRanking)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        /* check if a player played in similar competitions during his career */
        public bool ComparePlayerSimilarCompetitions(int playerId, int toClubId, int season)
        {
            if (playerId < 0) return false;

            var list = FetchTransfersForSpecificPlayer(playerId, season);

            if (list != null)
            {
                ClubsService clubsService = new(_db);
                CompetitionsService competitionsService = new CompetitionsService(_db);
                var currentClub = clubsService.GetClubByClubId(toClubId);

                foreach (var item in list)
                {
                    var previousClub = clubsService.GetClubByClubId(item);
                    if (previousClub != null && currentClub != null)
                    {
                        Competition previousClubCompetition = competitionsService.GetCompetitionById(previousClub.DomesticCompetitionId!);
                        Competition currentClubCompetition = competitionsService.GetCompetitionById(previousClub.DomesticCompetitionId!);

                        if (previousClubCompetition != null && currentClubCompetition != null)
                        {
                            if (previousClubCompetition.CompetitionRanking > currentClubCompetition.CompetitionRanking)
                            {
                                if (previousClubCompetition.CompetitionRanking - currentClubCompetition.CompetitionRanking <= 3)
                                    return true;
                            }
                            else if (previousClubCompetition.CompetitionRanking < currentClubCompetition.CompetitionRanking)
                            {
                                if (currentClubCompetition.CompetitionRanking - previousClubCompetition.CompetitionRanking <= 3)
                                    return true;
                            }
                            else
                            {
                                return true;
                            }
                        }   
                    }
                }
            }

            return false;
        }

        /* check if the player played in europe */
        public bool IsPlayedInEurope(int playerId, int season)
        {
            var previousTransfers = FetchTransfersForSpecificPlayer(playerId, season - 1);

            if (previousTransfers != null && previousTransfers.Any())
            {
                ClubsService clubsService = new(_db);

                foreach (var item in previousTransfers)
                {
                    var previousClub = clubsService.GetClubByClubId(item);

                    if (previousClub != null && previousClub.IsEuropean)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
