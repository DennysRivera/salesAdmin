using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salesAdmin.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string Client { get; set; } = "";
    public string? Description { get; set; }
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string Contact { get; set; } = "";
    public double TotalPrice { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public bool IsPaid { get; set; }
}
