using salesAdmin.Models;

namespace salesAdmin.Repository.Interfaces;

public interface ISaleRepository
{
Task CreateSale(Sale sale);
    Task<List<Sale>> GetSales();
    Task<bool> SaleExists(int id);
    Task UpdateSale(Sale sale);
    Task DeleteSale(int id);
}
