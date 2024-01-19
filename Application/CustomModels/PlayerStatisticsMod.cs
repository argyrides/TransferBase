namespace TransferBase.Application.CustomModels
{
    public class PlayerStatisticsMod
    {
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public int PlayerClubId { get; set; }
        public string? ClubName { get; set; }   
        public int Goals { get; set; }
        public int Assists { get;set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int MinutesPlayed { get; set; }
        public int Season { get; set; }

        public bool isChecked { get; set; }
    }
}
