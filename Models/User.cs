using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salesAdmin.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(15)")]
    [Required]
    public string Type { get; set; } = "";
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string FirstName { get; set; } = "";
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string LastName { get; set; } = "";
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string Mail { get; set; } = "";
    [Column(TypeName = "varchar")]
    [Required]
    public string Password { get; set; } = "";
}
