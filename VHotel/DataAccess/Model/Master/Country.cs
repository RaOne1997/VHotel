using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Master;
[Table("CountryMaster", Schema = "MasterData")]
public class Country : DataModelBase
{
 
    public string CountryID { get; set; } = null!;
    public string CountryCode { get; set; } = null!;
    public string CountryName { get; set; } = null!;
}
