using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class PlayerValue : BaseModel
    {
        public int PlayerId { get; set; }
        public int LastSeason { get; set; }
        public string? Datetime { get; set; }
        public string? Date { get; set; }
        public DateTime DateWeek { get; set; }
        public int MarketValueInEur { get; set; }
        public string? N { get; set; }
        public int ClubId { get; set; }
        public string? PlayerClubDomesticCompetitionId { get; set; }
        public int Season { get; set; }

        public virtual Player? Player { get; set; }
        public virtual Club? Club { get; set; }

    }
}
