using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;


[Table("RoomTypes", Schema = "RoomDetails")]
[Index(nameof(RoomType), IsUnique=true)]
public class Type : DataModelBase
{
   
    public string RoomType { get; set; } = null!;

}