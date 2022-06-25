using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CountryMaster", Schema = "Location")]

[Index(nameof(CountryID), IsUnique = true)]
public class Country
{
    public int Id { get; set; }
    public string CountryID { get; set; } = null!;
    public string CountryCode { get; set; } = null!;
    public string CountryName { get; set; } = null!;
}
