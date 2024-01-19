namespace TransferBase.Application.CustomModels
{
    public class PlayerMarketValueMod
    {
        public int PlayerId { get; set; }
        public int PlayerValue { get; set; }
    }

    public class PlayerSamePositionMod
    {
        public int PlayerId { get; set; }
        public string? Position { get; set; }
    }

    public class PlayerSameNationality
    {
        public int PlayerId { get; set; }
        public string? Nationality { get; set; }
    }
}
