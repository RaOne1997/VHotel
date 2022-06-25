using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("RoomTypes", Schema = "RoomDetails")]
[Index(nameof(RoomType), IsUnique=true)]
public class Type
{
    public int Id { get; set; }
    public string RoomType { get; set; } = null!;

}