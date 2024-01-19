using TransferBase.Application.Database;

namespace TransferBase.Application.Services.General
{
    public class CoachesService
    {
        private readonly DatabaseContext _db;
        public CoachesService(DatabaseContext db)
        {
            _db = db;
        }

        /* return the nationality of a specific coach */
        public string GetCoachNationality(int coachId)
        {
            if (coachId <= 0)
                return "";

            return _db.Coaches.Where(a => a.Id == coachId).Select(a => a.Citizenship).FirstOrDefault()!;
        }

        /* return the average time that a specific coach has in his career */
        public double GetCoachAverageTime(int coachId)
        {
            if (coachId <= 0)
                return 0;

            return _db.Coaches.Where(a => a.Id == coachId).Select(a => a.AvgTermAsCoach).FirstOrDefault();
        }
    }
}
