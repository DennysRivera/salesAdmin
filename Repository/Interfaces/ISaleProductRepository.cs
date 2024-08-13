using salesAdmin.Models;

namespace salesAdmin.Repository.Interfaces;

public interface ISaleProductRepository
{
    Task CreateSaleProduct(SaleProduct saleProduct);
    Task<List<SaleProduct>> GetSaleProducts();
    Task PaySaleProduct(SaleProduct saleProduct);
}
