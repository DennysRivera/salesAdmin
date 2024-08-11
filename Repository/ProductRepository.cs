using Microsoft.EntityFrameworkCore;
using salesAdmin.Data;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;

namespace salesAdmin.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext context;

    public ProductRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task CreateProduct(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        await context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<Product>> GetProducts()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<bool> ProductExists(int id)
    {
        return await context.Products.AnyAsync(p => p.Id == id);
    }

    public async Task UpdateProduct(Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
    }
}
