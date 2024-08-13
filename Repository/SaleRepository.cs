using Microsoft.EntityFrameworkCore;
using salesAdmin.Data;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;

namespace salesAdmin.Repository;

public class SaleRepository : ISaleRepository
{
    private readonly ApplicationDbContext context;

    public SaleRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<int> CreateSale(Sale sale)
    {
        context.Add(sale);
        await context.SaveChangesAsync();
        return sale.Id;
    }

    public async Task DeleteSale(int id)
    {
        await context.Sales.Where(s => s.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<Sale>> GetSales()
    {
        return await context.Sales.ToListAsync();
    }

    public async Task<bool> SaleExists(int id)
    {
        return await context.Sales.AnyAsync(s => s.Id == id);
    }

    public async Task UpdateSale(Sale sale)
    {
        context.Update(sale);
        await context.SaveChangesAsync();
    }
}
