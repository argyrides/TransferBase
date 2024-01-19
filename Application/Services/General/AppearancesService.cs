using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class AppearancesService
    {
        private readonly DatabaseContext _db;
        public AppearancesService(DatabaseContext db)
        {
            _db = db;
        }

        /* return the goals conceded a specific player in a specific season */
        public int GetGoalsConceded(int playerId, int season)
        {
            int goalsConceded = 0;

            if (playerId <= 0 || season <= 0)
                return -1;

            var query = (from ap in _db.Appearances
                        join g in _db.Games on ap.GameId equals g.Id
                        where ap.PlayerId == playerId && ap.Season == season
                        select new
                        {
                            HomeGoals = g.HomeClubGoals,
                            AwayGoals = g.AwayClubGoals,
                            HomeClubId = g.HomeClubId,
                            AwayClubId = g.AwayClubId,
                            PlayerClubId = ap.ClubId
                        }).ToList();

            foreach (var item in query)
            {
                if (item.HomeClubId == item.PlayerClubId)
                    goalsConceded += Convert.ToInt32(item.AwayGoals);
                else
                    goalsConceded += Convert.ToInt32(item.HomeGoals);
            }

            return goalsConceded;
        }

        /* return the teams change a player during his career */
        public int GetTeamsChangedDuringCareer(int playerId)
        {
            if (playerId <= 0)
                return -1;

            var teamsChanged = (from appearance in _db.Appearances
                                where appearance.PlayerId == playerId
                                group appearance by new
                                {
                                    appearance.PlayerId,
                                    appearance.ClubId,
                                    appearance.LastAppearance
                                } into grouped
                                orderby grouped.Key.PlayerId, grouped.Key.LastAppearance
                                select new
                                {
                                    grouped.Key.PlayerId,
                                    grouped.Key.ClubId,
                                    grouped.Key.LastAppearance
                                }).ToList();

            return teamsChanged.Count;
        }

        /* return the appearances of a player in a specific season */
        public List<Appearance> GetPlayerAppearances(int playerId, int season)
        {
            if (playerId <= 0 || season <= 0)
                return null;

            return _db.Appearances.Where(a => a.PlayerId == playerId && a.Season == season).ToList();
        }

        public int GetCleanSheets(int playerId, int clubId, int season)
        {
            int cleanSheets = 0;

            if (playerId <= 0 || season <= 0 || clubId <= 0)
                return 0;

            var appearances = (from ap in _db.Appearances
                               where ap.PlayerId == playerId && ap.Season == season
                               select ap).ToList();
                
                
                
            //_db.Appearances.Where(a => a.PlayerId == playerId && a.Season == season).ToList();
            var gamesListIds = new List<string>();

            if (appearances.Any())
            {
                foreach (var item in appearances)
                    gamesListIds.Add(item.GameId!);
            }

            foreach (var gameId in gamesListIds)
            {
                var clubGamesList = _db.ClubGames.Where(a => a.GameId!.Trim() == gameId.Trim() && a.ClubId == clubId).ToList();

                foreach (var clubGame in clubGamesList)
                {
                    if (clubGame.OpponentGoals == 0)
                        cleanSheets++;
                }
            }

            return cleanSheets;
        }
    }
}
