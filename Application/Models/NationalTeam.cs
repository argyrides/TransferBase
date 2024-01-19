using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class NationalTeam : BaseModel
    {
        public string? Name { get; set; }
        public int Ranking { get; set; }
    }
}
