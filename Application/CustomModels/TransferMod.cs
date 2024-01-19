using TransferBase.Application.Models;

namespace TransferBase.Application.CustomModels
{
    public class TransferMod
    {
        public Player? Player { get; set; }
        public PlayerSkill? PlayerSkill { get; set; }
        public int ClubFromId { get; set; }
        public int ClubToId { get; set; }
        public int PreviousSeasonGoals { get; set; }
        public int PreviousSeasonAssists { get; set; }
        public int PreviousSeasonMinutesPlayed { get; set; }
        public int PreviousSeasonCleanSheets { get; set; }
        public int PreviousSeasonYellowCards { get; set; }
        public int PreviousSeasonRedCards { get; set; }
        public int CurrentSeasonGoals { get; set; }
        public int CurrentSeasonAssists { get; set; }
        public int CurrentSeasonMinutesPlayed { get; set; }
        public int CurrentSeasonCleanSheets { get; set; }

        public int Season { get; set; }
        public int TeamsChanged { get; set; }
    }
}
