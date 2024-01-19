using Microsoft.EntityFrameworkCore;
using TransferBase.Application.CustomModels;
using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class ClubsService
    {
        private readonly DatabaseContext _db;


        public ClubsService(DatabaseContext db)
        {
            _db = db;
        }

        /* return all clubs */
        public async Task<List<Club>> GetAllClubs()
        {
            return await _db.Clubs.ToListAsync();
        }

        /* return a club based on id */
        public Club GetClubByClubId(int clubId)
        {
            if (clubId <= 0)
                return null;

            return _db.Clubs.Where(a => a.Id == clubId).FirstOrDefault()!;
        }

        /* return a club based its name */
        public Club GetClubByClubName(string name)
        {
            if (name == null)
                return null;

            return _db.Clubs.Where(a => a.Name == name).FirstOrDefault()!;
        }

        /* return a club id based its name */
        public int GetClubIdByName(string name)
        {
            if (name == null)
                return -1;

            return _db.Clubs.Where(a => a.Name == name).FirstOrDefault()!.Id!;
        }

        /* return club name based its id */
        public string GetClubNameByClubId(int clubId)
        {
            if (clubId <= 0)
                return "";

            Club club = _db.Clubs.Where(a => a.Id == clubId).FirstOrDefault()!;
            return (club != null) ? club.Name! : "";
        }

        /* return the sum of all player valuations of specific club in a specific season */
        public int GetClubPlayerValuation(int clubId, int season)
        {
            if (clubId <= 0 || season <= 0)
                return 0;

            var result = (from ap in _db.Appearances
                         join pl in _db.Players on ap.PlayerId equals pl.Id
                         where ap.Season == season && ap.ClubId == clubId
                         group pl.MarketValueInEur by new { ap.PlayerId, pl.MarketValueInEur } into grouped
                         select new PlayerMarketValueMod
                         {
                             PlayerId = grouped.Key.PlayerId,
                             PlayerValue = grouped.Key.MarketValueInEur
                         }).ToList();

            return result.Sum(a => a.PlayerValue);

        }

        /* return the average of players valuations of specific club in a specific season */
        public int GetClubAveragePlayerValuation(int clubId, int season)
        {
            if (clubId <= 0 || season <= 0)
                return 0;

            var result = (from ap in _db.Appearances
                          join pl in _db.Players on ap.PlayerId equals pl.Id
                          where ap.Season == season && ap.ClubId == clubId
                          group pl.MarketValueInEur by new { ap.PlayerId, pl.MarketValueInEur } into grouped
                          select new PlayerMarketValueMod
                          {
                              PlayerId = grouped.Key.PlayerId,
                              PlayerValue = grouped.Key.MarketValueInEur
                          }).ToList();

            if (result.Any())
                return result.Sum(a => a.PlayerValue) / result.Count;

            return 0;
        }

        /* return the value of the best player of a specific club in a specific season for specific position */
        public int GetTeamBestPlayerInSpecificPosition(int clubId, int season, string position)
        {
            if (clubId <= 0 || season <= 0)
                return 0;

            var result = (from ap in _db.Appearances
                          join pl in _db.Players on ap.PlayerId equals pl.Id
                          where ap.Season == season && ap.ClubId == clubId && pl.SubPosition == position
                          group pl.MarketValueInEur by new { ap.PlayerId, pl.MarketValueInEur } into grouped
                          select new PlayerMarketValueMod
                          {
                              PlayerId = grouped.Key.PlayerId,
                              PlayerValue = grouped.Key.MarketValueInEur
                          }).ToList();

            if (result.Any())
                return result.Max(a => a.PlayerValue);

            return 0;
        }

        /* return the average values of the players of a specific club in a specific season for specific position */
        public int GetClubAveragePlayerValuationByPosition(int clubId, int season, string position)
        {
            if (clubId <= 0 || season <= 0)
                return 0;

            var result = (from ap in _db.Appearances
                          join pl in _db.Players on ap.PlayerId equals pl.Id
                          where ap.Season == season && ap.ClubId == clubId && pl.SubPosition == position
                          group pl.MarketValueInEur by new { ap.PlayerId, pl.MarketValueInEur, pl.SubPosition } into grouped
                          select new PlayerMarketValueMod
                          {
                              PlayerId = grouped.Key.PlayerId,
                              PlayerValue = grouped.Key.MarketValueInEur
                          }).ToList();

            if (result != null && result.Count > 0)
                    return result.Sum(a => a.PlayerValue) / result.Count;

            return 0;
        }

        /* return the number of players of a specific club in a specific season that has same position */
        public int GetClubPlayersInSamePosition(int clubId, int season, string position)
        {
            if (clubId <= 0 || season <= 0 || position == null)
                return 0;

            var result = (from ap in _db.Appearances
                          join pl in _db.Players on ap.PlayerId equals pl.Id
                          where ap.Season == season && ap.ClubId == clubId && pl.SubPosition == position
                          group pl.MarketValueInEur by new { ap.PlayerId, pl.MarketValueInEur, pl.SubPosition } into grouped
                          select new PlayerSamePositionMod
                          {
                              PlayerId = grouped.Key.PlayerId,
                              Position = grouped.Key.SubPosition
                          }).ToList();

            return result.Count();
        }

        /* return the number of players that has same nationality of a specific club in a specific season that has same position */
        public int GetClubPlayersSameNationality(int clubId, int season, string nationality)
        {
            if (clubId <= 0 || season <= 0 || nationality == null)
                return 0;

            var result = (from ap in _db.Appearances
                          join pl in _db.Players on ap.PlayerId equals pl.Id
                          where ap.Season == season && ap.ClubId == clubId && pl.CountryOfBirth == nationality
                          group pl.MarketValueInEur by new { ap.PlayerId, pl.MarketValueInEur, pl.CountryOfBirth } into grouped
                          select new PlayerSameNationality
                          {
                              PlayerId = grouped.Key.PlayerId,
                              Nationality = grouped.Key.CountryOfBirth
                          }).ToList();

            return result.Count();

        }

        /* return the id of the coach of specific club */
        public int GetClubCoachId(int clubId)
        {
            if (clubId < 0)
                return 0;

            return _db.Clubs.Where(a => a.Id == clubId).Select(a => a.CoachId).FirstOrDefault();
        }

        /* return the id of a competition of specific club */
        public string GetClubCompetition(int clubId)
        {
            if (clubId < 0)
                return "";

            return _db.Clubs.Where(a => a.Id == clubId).Select(a => a.DomesticCompetitionId).FirstOrDefault()!;
            
        }
    }
}
