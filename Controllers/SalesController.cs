using System.Text.Json;
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
            ExistingProducts = existingProducts
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest(SaleRequestViewModel viewModel, string soldProducts)
    {
        if (ModelState.IsValid)
        {
            List<ProductDto> soldProductsList = [];
            soldProducts = soldProducts.Remove(0, 1);
            soldProducts = soldProducts.Remove(soldProducts.Length-1, 1);
            
            Sale sale = new()
            {
                Client = viewModel.NewSale.Client,
                Description = viewModel.NewSale.Description,
                Contact = viewModel.NewSale.Contact,
                TotalPrice = viewModel.NewSale.TotalPrice,
                CreationDate = DateTime.Now.ToUniversalTime(),
                IsPaid = false
            };
            
            int saleId = await saleRepository.CreateSale(sale);

            return RedirectToAction("CreateRequest");
        }
        else
        {
            foreach(var state in ModelState){
                foreach(var error in state.Value.Errors){
                    Console.WriteLine(error.ErrorMessage);
                }
            }
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
            viewModel.ExistingProducts = existingProducts;
        }

        return View(viewModel);
    }
}
