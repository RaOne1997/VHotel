﻿

namespace VHotel.DataAccess.DTo
{
    public class CityMasterdto: ViewModelBase
    {
        
        public string CityName { get; set; } = null!;
        public int stateRefID { get; set; }
        public string? stateName { get; set; }

    }

}

