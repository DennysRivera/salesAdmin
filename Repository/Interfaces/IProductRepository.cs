using salesAdmin.Models;

namespace salesAdmin.Repository.Interfaces;

public interface IProductRepository
{
    Task CreateProduct(Product product);
    Task<List<Product>> GetProducts();
    Task<bool> ProductExists(int id);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int id);
}
