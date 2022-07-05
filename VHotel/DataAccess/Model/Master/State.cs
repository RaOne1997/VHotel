using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Master;
[Table("StateMaster", Schema = "MasterData")]

public class State : DataModelBase
{

    public string StateID { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public int CountryrefID { get; set; }
    [ForeignKey(nameof(CountryrefID))]
    public Country Countryref { get; set; } = null!;

}