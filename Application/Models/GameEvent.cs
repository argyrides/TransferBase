namespace TransferBase.Application.Models
{
    public class GameEvent
    {
        public string? GameId { get; set; }
        public string? Minute { get; set; }
        public string? Type { get; set; }
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public string? Description { get; set; }
        public string? PlayerInId { get; set; }


        public virtual Game? Game { get; set; }
        public virtual Club? Club { get; set; }
        public virtual Player? Player { get; set;}
    }
}
