using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Masters
{
    [Table("CityMaster", Schema = "MasterData")]
    public class CityMaster : DataModelBase
    {
       
        public string CityName { get; set; } = null!;
        public int stateRefID { get; set; }
        [ForeignKey(nameof(stateRefID))]
        public State State { get; set; } = null!;
    }

}

