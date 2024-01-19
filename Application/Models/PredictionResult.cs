using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class PredictionResult : BaseModel
    {
        public string? PlayerName { get; set; }
        public string? PlayerPosition { get; set; }
        public string? ClubFrom { get; set; }
        public string? ClubTo { get; set; }
        public string? ClubToCompetition { get; set; }
        public int ClubToPlayerValuations { get; set; }
        public int ClubToAveragePlayerValuations { get; set; }
        public int ClubFromAveragePlayerValuations { get; set; }
        public bool IsPlayedInBiggerCompetitions { get; set; }
        public bool IsPlayedInSimilarCompetitions { get; set; }
        public int Age { get; set; }
        public string? PlayerNationality { get; set; }
        public int AppearancesWithNationalTeam { get; set; }
        public int NationalTeamWorldRanking { get; set; }
        public int InjuryRate { get; set; }
        public int HighestMarketValue { get; set; }
        public int CurrentMarketValue { get; set; }
        public int TeamsChangedDuringCareer { get; set; }
        public int NumberOfLocalsInNewTeam { get; set; }
        public int NumberOfPlayersInNewTeamSamePosition { get; set; }
        public int AverageMarketValueOfPlayerNewTeamSamePosition { get; set; }
        public int MaximumMarketValueOfPlayerNewTeamSamePosition { get; set; }
        public int NumberOfPlayersInNewTeamSameCountry { get; set; }
        public int AverageAttendanceOfNewTeam { get; set; }
        public int Adaptation { get; set; }
        public int Ambition { get; set; }
        public int Consistency { get; set; }
        public int ResistantToStress { get; set; }
        public int Professional { get; set; }
        public int PreviousSeasonGoals { get; set; }
        public int PreviousSeasonAssists { get; set; }
        public int PreviousSeasonTotalMinutesPlayed { get; set; }
        public int PreviousSeasonCleanSheets { get; set; }
        public int PreviousSeasonGoalsConceded { get; set; }
        public int PreviousSeasonKeeperSaves { get; set; }  
        public float AverageSkills { get; set; }
        public float TransferSuccess { get; set; }
    }
}
