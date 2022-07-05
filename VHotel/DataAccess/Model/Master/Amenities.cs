using System.ComponentModel.DataAnnotations;


namespace staticclassmodel.DataAccess.Model.Master
{
    public class Amenities : DataModelBase
    {
 
        [MaxLength(100)]
        public string Name { get; set; }= null!;
        [MaxLength(500)]
        public string Description { get; set; } = null!;
    }
}
