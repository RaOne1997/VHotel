using System.ComponentModel.DataAnnotations;


namespace staticclassmodel.DataAccess.Model.Master
{
    public class Amenities : DataModelBase
    {
 
        [MaxLength(100)]
        public string Name { get; set; }= null!;
        [MaxLength(100)]
        public string Description1 { get; set; } = null!;
        [MaxLength(100)]
        public string Description2 { get; set; } = null!;
        [MaxLength(100)]
        public string? Description3 { get; set; }
        [MaxLength(100)]
        public string? Description4 { get; set; }
        [MaxLength(100)]
        public string? Description5 { get; set; }
    }
}
