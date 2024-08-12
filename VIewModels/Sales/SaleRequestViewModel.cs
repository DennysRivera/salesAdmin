using salesAdmin.DTOs.Sale;
using salesAdmin.Models;

namespace salesAdmin.ViewModels.Sales;

public class SaleRequestViewModel
{
    public CreateSaleDto? NewSale { get; set; }
    public IEnumerable<Product>? ExistingProducts { get; set; }
    public List<Product>? ProductsToSell { get; set;}
}
