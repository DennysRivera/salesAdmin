using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salesAdmin.Models;

[Table("products")]
public class Product
{
    [Key]    
    public int Id { get; set; }
    [Column(TypeName = "varchar(150)")]
    [Required]
    public string Name { get; set; } = "";
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public bool Active { get; set; }
}
