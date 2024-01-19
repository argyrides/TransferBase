using Spark.Library.Database;

namespace TransferBase.Application.Models
{
    public class Coach : BaseModel
    {
        public string? Name { get; set; }
        public string? Club { get; set; }
        public string? Citizenship { get; set; }
        public double AvgTermAsCoach { get; set; }
        public string? PrefferedFormation { get; set; }
    }
}
