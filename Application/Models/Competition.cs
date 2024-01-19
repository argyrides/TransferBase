using Spark.Library.Database;

namespace TransferBase.Application.Models;

public class Competition : BaseModel
{
    public new string? Id { get; set; }
    public string? CompetitionCode { get; set; }
    public string? Name { get; set; }
    public string? SubType { get; set; }
    public string? Type { get; set; }
    public string? CountryId { get; set; }
    public string? CountryName { get; set; }
    public string? DomesticLeagueCode { get; set; }
    public string? Confederations { get; set; }
    public int CompetitionRanking { get; set; }
    public virtual ICollection<Appearance>? Appearances { get; set; }

}