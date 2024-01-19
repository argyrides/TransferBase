using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class Club : BaseModel
    {
        public string? ClubCode { get; set; }
        public string? Name { get; set; }  
        public string? DomesticCompetitionId { get; set; }
        public string? TotalMarketValue { get; set; }
        public int SquatSize { get; set; }
        public string? AverageAge { get; set; }
        public int ForeignersNumber { get; set; }
        public string? ForeignersPercentage { get; set; }
        public string? NationalTeamPlayers { get; set; }
        public string? StadiumName { get; set; }
        public string? StadiumSeats { get; set; }
        public string? NetTransferRecord { get; set; }
        public string? LastSeason { get; set; }
        public int CoachId { get; set; }
        public bool IsEuropean { get; set; }
        public virtual ICollection<ClubGame>? ClubGames { get; set; }
        public virtual ICollection<GameEvent>? GameEvents { get; set; }
        public virtual ICollection<PlayerValue>? PlayerValuations { get; set; }
        public virtual ICollection<Appearance>? Appearances { get; set; }

    }
}
