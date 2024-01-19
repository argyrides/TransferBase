using Microsoft.Identity.Client;
using Spark.Library.Database;

namespace TransferBase.Application.Models;

public class Transfer : BaseModel
{
    /* PARAGONTES */
    #region paragontes
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
    public int Age {  get; set; }
    public int Season { get; set; }
    public string? PlayerNationality { get; set; }
    public bool IsPlayedInEurope { get; set; }
    public int AppearancesWithNationalTeam { get; set; }
    public int NationalTeamWorldRanking { get; set; }
    public int InjuryRate { get; set; }
    public int HighestMarketValue { get; set; }
    public int CurrentMarketValue { get; set; }
    public int TeamsChangedDuringCareer { get; set; }
    public int LastYearAppearances { get; set; }
    public int NumberOfLocalsInNewTeam { get; set; }
    public int NumberOfPlayersInNewTeamSamePosition { get; set; }
    public int AverageMarketValueOfPlayerNewTeamSamePosition { get; set; }
    public int MaximumMarketValueOfPlayerNewTeamSamePosition { get; set; }
    public int NumberOfPlayersInNewTeamSameCountry { get; set; }
    //public int NumberOfPlayersInNewTeamSameLanguage { get; set; }
    public int AverageAttendanceOfNewTeam { get; set; }
    public string? CoachNationality { get; set; }
    public bool IsCoachMetThePlayerInAnotherTeamBefore { get; set; }
    //public string? CoachPlayingStyle { get; set; }
    public double CoachAverageTimeInTeam { get; set; }
    #endregion

    #region skills
    public int Acceleration { get; set; }
    public int AerialAbility { get; set; }
    public int Aggression { get; set; }
    public int Agility { get; set; }
    public int Anticipation { get; set; }
    public int Balance { get; set; }
    public int Bravery { get; set; }
    public int CommandOfArea { get; set; }
    public int Communication { get; set; }
    public int Composure { get; set; }
    public int Concentration { get; set; }
    public int Corners { get; set; }
    public int Crossing { get; set; }
    public int Decisions { get; set; }
    public int Determination { get; set; }
    public int Dribbling { get; set; }
    public int Eccentricity { get; set; }
    public int Finishing { get; set; }
    public int FirstTouch { get; set; }
    public int Flair { get; set; }
    public int FreeKickTaking { get; set; }
    public int Handling { get; set; }
    public int Heading { get; set; }
    public int JumpingReach { get; set; }
    public int Kicking { get; set; }
    public int Leadership { get; set; }
    public int LongShots { get; set; }
    public int LongThrows { get; set; }
    public int Marking { get; set; }
    public int NaturalFitness { get; set; }
    public int OffTheBall { get; set; }
    public int OneOnOnes { get; set; }
    public int Pace { get; set; }
    public int Passing { get; set; }
    public int PenaltyTaking { get; set; }
    public int Positioning { get; set; }
    public int Punching { get; set; }
    public int Reflexes { get; set; }
    public int RuchingOut { get; set; }
    public int Stamina { get; set; }
    public int Strength { get; set; }
    public int Tackling { get; set; }
    public int Teamwork { get; set; }
    public int Technique { get; set; }
    public int Throwing { get; set; }
    public int Vision { get; set; }
    public int WorkRate { get; set; }
    public int Adaptation { get; set; }
    public int Ambition { get; set; }
    public int Consistency { get; set; }
    public int ResistantToStress { get; set; }
    public int Professional { get; set; }

    #endregion

    /*data me egkatastaseis omadas???*/

    /* PROETOIMASIA!!!!!!!!!!!!!!!!!!!!!! */
    /* SKILLS */

    /* KRITIRIA */
    public int Goals { get; set; }
    public int Assists { get; set; }
    public int TotalMinutesPlayed { get; set; }
    public int CleanSheets { get; set; }

    public int PreviousSeasonGoals { get; set; }
    public int PreviousSeasonAssists { get; set; }
    public int PreviousSeasonTotalMinutesPlayed { get; set; }

    public int PreviousSeasonCleanSheets { get; set; }
    public int TransferPriceFuture { get; set; }
    public int GoalsConceded { get; set; }
    public int PreviousSeasonGoalsConceded { get; set; }
    public int KeeperSaves { get; set; }
    public int PreviousSeasonKeeperSaves { get; set; }
    public double ShotsOnTarget { get; set; }
    public double Clearances { get; set; }
    public double CompletedTacklings { get; set; }
    public double CompletedPasses { get; set; }
    public double AerialsWon { get; set; }

    // label / predicted value
    public double TransferSuccess { get; set; }
    public bool IsUpdate { get; set; }
    public double AverageStatsDefender { get; set; }
    public double AverageDefenderSkills { get; set; }
    public double AverageMidfielderSkills { get; set; }
    public double AverageAttackerSkills { get; set; }
}