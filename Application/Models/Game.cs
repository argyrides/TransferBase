using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class Game : BaseModel
    {
        public new string? Id { get; set; }
        public string? CompetitionId { get; set; }
        public int Season { get; set; }
        public string? Round { get; set; }
        public DateTime? Date { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
        public string? HomeClubGoals { get; set; }
        public string? AwayClubGoals { get; set; }
        public string? HomeClubPosition { get; set; }
        public string? AwayClubPosition { get; set; }
        public string? HomeClubManagerName { get; set; }
        public string? AwayClubManagerName { get; set; }
        public string? Stadium { get; set; }
        public int Attendance { get; set; }
        public string? Referre { get; set; }
        public string? Url { get; set; }
        public string? HomeClubName { get; set; }
        public string? AwayClubName { get; set; }
        public string? Aggregate { get; set; }
        public string? CompetitionType { get; set; }
        public string? NewFormattedDate{ get; set; }
        public int GkHomeSaves { get; set; }
        public int GkAwaySaves { get; set; }

        public virtual ICollection<ClubGame>? ClubGames { get; set; }
        public virtual ICollection<GameEvent>? GameEvents { get; set; }
        public virtual ICollection<Appearance>? Appearances { get; set; }

    }
}
