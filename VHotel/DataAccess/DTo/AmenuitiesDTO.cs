namespace VHotel.DataAccess.DTo
{
    public class AmenuitiesDTO : ViewModelBase
    {

        public string Name { get; set; } = null!;

        public string Description1 { get; set; } = null!;

        public string Description2 { get; set; } = null!;

        public string? Description3 { get; set; }

        public string? Description4 { get; set; }

        public string? Description5 { get; set; }
    }
}
