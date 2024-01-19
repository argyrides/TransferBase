using Microsoft.EntityFrameworkCore;
using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class ValuesService
    {
        private readonly DatabaseContext _db;

        public ValuesService(DatabaseContext db)
        {
            _db = db;
        }

        /* get the values of a specific player */
        public List<PlayerValue> GetValuesByPlayerId(int playerId)
        {
            return _db.PlayerValues.Where(a => a.PlayerId == playerId).Where(ap => ap.Season >= 2017 && ap.Season <= 2021).OrderBy(a => a.DateWeek)
                    .ToList();
        }

        /* get highest player market value before the season specified on function's parameter */
        public int GetHighestMarketValueOfPlayer(int playerId, int season)
        {
            var playerValues = _db.PlayerValues.Where(a => a.PlayerId == playerId && a.Season <= season).ToList();

            if (playerValues.Count <= 0)
                return 0;

            return playerValues.Max(a => a.MarketValueInEur);
        }

        /* get  player average market value the season specified on function's parameter */
        public int GetMarketValueOfPlayer(int  playerId, int season)
        {
            var playerValues = _db.PlayerValues.Where(a => a.PlayerId == playerId && a.Season == season).ToList();

            if (playerValues.Count <= 0)
                return 0;

            return playerValues.Sum(a => a.MarketValueInEur) / playerValues.Count();
        }

        /* return the current value of a specific player */
        public int GetCurrentValueOfPlayer(int playerId)
        {
            var maxDate = _db.PlayerValues.Where(a => a.PlayerId == playerId).Max(a => a.DateWeek);
            return _db.PlayerValues.Where(a => a.PlayerId == playerId && a.DateWeek == maxDate).Select(a => a.MarketValueInEur).FirstOrDefault();
        }
    }
}
