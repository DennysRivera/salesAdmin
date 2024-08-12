using salesAdmin.DTOs.Product;

namespace salesAdmin.ViewModels.Products;

public class ProductsViewModel
{
    public List<ProductDto>? ExistingProducts { get; set; }
    public CreateProductDto? NewProduct { get; set; }
    public ProductDto? Product { get; set; }
}
