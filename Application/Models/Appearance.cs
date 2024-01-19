using Spark.Library.Database;
using System.Reflection.Metadata;

namespace TransferBase.Application.Models
{
    public class Appearance : BaseModel
    {
        public new string? Id {get;set;}
        public string? GameId { get; set; }
        public int PlayerId { get; set; }
        public int ClubId {  get; set; }
        public int PlayerCurrentClubId { get; set; }
        public DateTime? Date { get; set; }
        public string? PlayerName { get; set; }
        public string? CompetitionId { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int Season { get; set; }
        public string? FormattedDate { get; set; }

        public DateTime LastAppearance { get; set; }
        //public virtual Game? Game { get; set; }
        //public virtual Player? Player { get; set; }
        //public virtual Club? Club { get; set; }
        //public virtual Competition? Competition { get; set; }

    }
}
