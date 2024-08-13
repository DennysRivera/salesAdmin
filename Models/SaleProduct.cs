using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salesAdmin.Models;

public class SaleProduct
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Sale))]
    public int SalesId { get; set; }
    public Sale Sale { get; set; }
    [ForeignKey(nameof(Product))]
    public int ProductsId { get; set; }
    public Product Product { get; set; }
}
