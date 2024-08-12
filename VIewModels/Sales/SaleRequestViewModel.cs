using salesAdmin.Models;

namespace salesAdmin.ViewModels.Sales;

public class SaleRequestViewModel
{
    public User? User { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}
