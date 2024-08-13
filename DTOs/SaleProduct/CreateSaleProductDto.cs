using salesAdmin.Models;

namespace salesAdmin.DTOs.SaleProduct;

public class CreateSaleProductDto
{
    public Models.Sale Sale { get; set; }
    public Models.Product Product { get; set; }
}
