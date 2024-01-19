using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class GamesService
    {
        private readonly DatabaseContext _db;
        public GamesService(DatabaseContext db)
        {
            _db = db;
        }

        /* return the number of goals a club conceded in a specific game */
        public int GetGoalsConceded(string gameId, int clubId)
        {
            if (gameId is null || clubId <= 0)
                return 0;

            return _db.ClubGames.Where(a => a.GameId!.Trim() == gameId.Trim() && a.ClubId == clubId).Select(a => a.OpponentGoals).FirstOrDefault();
        }

        /* return the number of keeper saves in a specific game */
        public int GetKeeperSaves(string gameId, int clubId)
        {
            if (gameId is null || clubId <= 0)
                return 0;

            var game = _db.Games.Find(gameId);

            if (game != null)
            {
                if (game.HomeClubId == clubId)
                {
                    return game.GkHomeSaves;
                }
                else if (game.AwayClubId == clubId)
                {
                    return game.GkAwaySaves;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }

        /* return the average attendance of specific club in a specific season */
        public int GetAverageAttendance(int clubId, int season)
        {
            if (clubId <= 0 || season <= 0)
                return 0;

            var homeGames = _db.Games.Where(a => a.HomeClubId == clubId && a.Season == season).ToList();

            if (homeGames.Any())
                return homeGames.Sum(a => a.Attendance) / homeGames.Count();

            return 0;
        }

    }
}
