using Microsoft.EntityFrameworkCore;
using salesAdmin.Data;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;

namespace salesAdmin.Repository;

public class SaleProductRepository : ISaleProductRepository
{
    private readonly ApplicationDbContext context;

    public SaleProductRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task CreateSaleProduct(SaleProduct saleProduct)
    {
        context.Add(saleProduct);
        await context.SaveChangesAsync();
    }

    public async Task<List<SaleProduct>> GetSaleProducts()
    {
        return await context.SalesProducts.ToListAsync();
    }

    public async Task PaySaleProduct(SaleProduct saleProduct)
    {
        context.Update(saleProduct);
        await context.SaveChangesAsync();
    }
}
