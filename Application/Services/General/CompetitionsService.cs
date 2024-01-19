using TransferBase.Application.Database;
using TransferBase.Application.Models;

namespace TransferBase.Application.Services.General
{
    public class CompetitionsService
    {
        private readonly DatabaseContext _db;

        public CompetitionsService(DatabaseContext db)
        {
            _db = db;
        }

        /* return the competition */
        public Competition GetCompetitionById(string competitionId)
        {
            if (competitionId == "" && competitionId == null)
                return null;

            return _db.Competitions.Where(a => a.Id == competitionId).FirstOrDefault()!;
        }
    }
}
