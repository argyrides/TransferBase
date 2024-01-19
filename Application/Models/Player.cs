using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class Player : BaseModel
    {
        public Player() { }
       
        public int UID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Name { get; set; }
        public string? LastSeason { get; set; }
        public int CurrentClubId { get; set; }
        public string? CountryOfBirth { get; set; }
        public string? CountryOfCitizenship { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Position { get; set; }
        public string? SubPosition { get; set; }
        public string? Foot { get; set; }
        public string? HeightInCM { get; set; }
        public int MarketValueInEur { get; set; }
        public int HighestMarketValueInEur { get; set; }
        public string? ContractExpirationDate { get; set; }
        public string? AgentName { get; set; }
        public string? CurrentClubDomesticCompetitionId { get; set; }
        public string? CurrentClubName { get; set; }
       

        public virtual ICollection<GameEvent>? GameEvents { get; set; }
        public virtual ICollection<PlayerValue>? PlayerValuations { get; set; }
        public virtual ICollection<Appearance>? Appearances { get; set; }

    }
}
