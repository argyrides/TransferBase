namespace TransferBase.Application.Models
{
    public class ClubGame
    {
        public string? GameId { get; set; }
        public int ClubId { get; set; }  
        public int OwnGoals { get; set; }
        public string? OwnPosition { get; set; }
        public string? OwnManagerName { get; set; }
        public string? OpponentId { get; set; }
        public int OpponentGoals { get; set; }
        public string? OpponentPosition { get; set; }
        public string? OpponentManagerName { get; set; }
        public string? Hosting { get; set; }
        public string? IsWin { get; set; }

        public virtual Game? Game { get; set; }
        public virtual Club? Club { get; set; }
    }
}
