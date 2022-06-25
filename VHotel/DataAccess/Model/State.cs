using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("StateMaster", Schema = "Location")]
[Index(nameof(StateID), IsUnique = true)]
public class State
{
    public int Id { get; set; }
    public string StateID { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public int CountryrefID { get; set; }
    [ForeignKey(nameof(CountryrefID))]
    public Country Countryref { get; set; } = null!;

}