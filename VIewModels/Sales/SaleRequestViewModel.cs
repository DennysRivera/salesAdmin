using salesAdmin.DTOs.Product;
using salesAdmin.DTOs.Sale;
using salesAdmin.Models;

namespace salesAdmin.ViewModels.Sales;

public class SaleRequestViewModel
{
    public CreateSaleDto? NewSale { get; set; }
    public IEnumerable<ProductDto>? ExistingProducts { get; set; }
    public List<ProductDto>? ProductsToSell { get; set;}
}
