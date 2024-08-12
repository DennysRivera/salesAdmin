using Microsoft.AspNetCore.Mvc;
using salesAdmin.Data;
using salesAdmin.DTOs.Product;
using salesAdmin.DTOs.Sale;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;
using salesAdmin.ViewModels.Sales;

namespace salesAdmin.Controllers;

public class SalesController : Controller
{
    private readonly ISaleRepository saleRepository;
    private readonly IProductRepository productRepository;
    public SalesController(ISaleRepository saleRepository, IProductRepository productRepository)
    {
        this.saleRepository = saleRepository;
        this.productRepository = productRepository;
    }

    public async Task<IActionResult> CreateRequest()
    {
        List<ProductDto> existingProducts = [];
        IEnumerable<Product> products = await productRepository.GetProducts();
        foreach (Product p in products)
        {
            existingProducts.Add(new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
                Quantity = p.Quantity,
                Active = p.Active
            });
        }
         SaleRequestViewModel viewModel = new()
        {
            ExistingProducts = products
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest(CreateSaleDto saleDto)
    {
        if (ModelState.IsValid)
        {
            Sale sale = new()
            {
                Client = saleDto.Client,
                Description = saleDto.Description,
                Contact = saleDto.Contact,
                TotalPrice = saleDto.TotalPrice,
                CreationDate = DateTime.Now.ToUniversalTime(),
                IsPaid = false
            };

            await saleRepository.CreateSale(sale);
            return RedirectToAction("CreateRequest");
        }

        return View(saleDto);
    }
}
