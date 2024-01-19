using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class NationalTeamsService
    {
        private readonly DatabaseContext _db;

        public NationalTeamsService(DatabaseContext db)
        {
            _db = db;
        }

        /* return the ranking of a specific national team */
        public int GetNationalTeamRanking(string name)
        {
            return _db.NationalTeams.Where(a => a.Name == name).Select(a => a.Ranking).FirstOrDefault();
        }

        
    }
}
