using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.Master
{
    [Table("CityMaster", Schema = "MasterData")]
    public class CityMaster
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; } = null!;
        public int stateRefID { get; set; }
        [ForeignKey(nameof(stateRefID))]
        public State State { get; set; } = null!;
    }




    public class CityMasterdto
    {
        public string CityName { get; set; } = null!;
        public int stateRefID { get; set; }

    }

}

