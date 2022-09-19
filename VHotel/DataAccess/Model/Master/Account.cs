using staticclassmodel.DataAccess.Model.Masters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vhotel.DataAccess.Model.Master
{
    [Table("Account", Schema = "Master")]
    public class Account : DataModelBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "Nvarchar(10)")]
        public string Phone { get; set; }
        public string Password{get;set;}
    }
}
