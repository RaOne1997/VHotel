using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CountryMaster", Schema = "MasterData")]


public class Country
{
    public int Id { get; set; }
    public string CountryID { get; set; } = null!;
    public string CountryCode { get; set; } = null!;
    public string CountryName { get; set; } = null!;
}
