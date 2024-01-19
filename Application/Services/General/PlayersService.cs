using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using TransferBase.Application.CustomModels;
using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class PlayersService
    {
        private readonly DatabaseContext _db;

        [Inject]
        public ClubsService ClubsService { get; set; } = default!;

        public PlayersService(DatabaseContext db)
        {
            _db = db;
        }

        //public async Task<List<Club>> FetchAllClubs()
        //{
        //    using var context = _factory.CreateDbContext();
        //    return await context.Clubs.ToListAsync();
        //}

        //public async Task<Player?> FindPlayerAsync(int playerId)
        //{
        //    using var context = _factory.CreateDbContext();
        //    return await context.Players.FindAsync(playerId);
        //}

        //public async Task<Player?> FindPlayerAsync(string fullName)
        //{
        //    using var context = _factory.CreateDbContext();
        //    return await context.Players.FirstOrDefaultAsync(x => x.Name!.Contains(fullName));
        //}

        /* return all the players after the season specific on function's parameter*/
        public async Task<List<Player>> GetAllPlayersAsync(int season)
        {
            return await _db.Players.Where(a => Convert.ToInt32(a.LastSeason) >= season).ToListAsync();
        }

        /* return all the players */
        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _db.Players
                    .ToListAsync();
        }

        /* get specific player based his id async */
        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            return await _db.Players.Where(a => a.Id == playerId).FirstOrDefaultAsync();
        }

        /* get specific player based his id */
        public Player GetPlayerById(int playerId)
        {
            return _db.Players.Where(a => a.Id == playerId).FirstOrDefault()!;
        }

        /* return player id based in name async */
        public async Task<int>? GetPlayerIdByNameAsync(string name)
        {
            Player player = await _db.Players.Where(a => a.Name == name).FirstOrDefaultAsync();
            return (player != null) ? player.Id : -1;
        }

        /* return player id based in name */
        public int GetPlayerIdByName(string name)
        {
            if (name == null)
                return -1;

            Player player = _db.Players.Where(a => a.Name == name).FirstOrDefault()!;
            return (player != null) ? player.Id : -1;
        }

        /* return player statistics between 2017-2021 seasons (playerclubid, clubname, goals, assists, yc, rc, mp, season) */
        public List<PlayerStatisticsMod> GetPlayerStatisticsPerTeam(int playerId)
        {
            try
            {
                var result = _db.Appearances
                             .Where(ap => ap.PlayerId == playerId)
                             .Where(ap => ap.Season >= 2017 && ap.Season <= 2021)
                             .GroupBy(ap => new { ap.ClubId, ap.Season })
                             .Select(grouped => new PlayerStatisticsMod
                             {
                                 PlayerClubId = grouped.Key.ClubId,
                                 ClubName = _db.Clubs.Where(a => a.Id == grouped.Key.ClubId).FirstOrDefault()!.Name,
                                 Goals = grouped.Sum(ap => ap.Goals),
                                 Assists = grouped.Sum(ap => ap.Assists),
                                 YellowCards = grouped.Sum(ap => ap.YellowCards),
                                 RedCards = grouped.Sum(ap => ap.RedCards),
                                 MinutesPlayed = grouped.Sum(ap => ap.MinutesPlayed),
                                 Season = grouped.Key.Season
                             })
                             .ToList();

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        /* return player statistics in specific season (playerclubid, clubname, goals, assists, yc, rc, mp, season) */
        public PlayerStatisticsMod GetPlayerStatistics(int playerId, int season)
        {
            try
            {
                var result = _db.Appearances
                             .Where(ap => ap.PlayerId == playerId)
                             .Where(ap => ap.Season == season)
                             .GroupBy(ap => new { ap.ClubId, ap.Season })
                             .Select(grouped => new PlayerStatisticsMod
                             {
                                 PlayerClubId = grouped.Key.ClubId,
                                 ClubName = _db.Clubs.Where(a => a.Id == grouped.Key.ClubId).FirstOrDefault()!.Name,
                                 Goals = grouped.Sum(ap => ap.Goals),
                                 Assists = grouped.Sum(ap => ap.Assists),
                                 YellowCards = grouped.Sum(ap => ap.YellowCards),
                                 RedCards = grouped.Sum(ap => ap.RedCards),
                                 MinutesPlayed = grouped.Sum(ap => ap.MinutesPlayed),
                                 Season = grouped.Key.Season
                             })
                             .FirstOrDefault();

                return result!;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
