﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Masters
{
    [Table("AirlineDetails", Schema = "Master")]
    public class AirlineDetails : DataModelBase
    {
       
        public string AirlineName { get; set; }= null!;
        public string ShortName { get; set; } = null!;
        public byte[]? AirlineLogo { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Number Is not validate")]
        public long HelplineNumber { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Number Is not validate")]
        public long? Telephone2 { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail 1 is not valid")]
        public string Email1 { get; set; } = null!;
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail 2 is not valid")]
        public string? Email2 { get; set; } = null!;
    }
}
