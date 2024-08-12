using Microsoft.AspNetCore.Mvc;
using salesAdmin.DTOs.Product;
using salesAdmin.DTOs.User;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;
using salesAdmin.ViewModels.Products;

namespace salesAdmin.Controllers;

public class AdminController : Controller
{
    private readonly IProductRepository productRepository;
    private readonly IUserRepository userRepository;

    public AdminController(IProductRepository productRepository, IUserRepository userRepository)
    {
        this.productRepository = productRepository;
        this.userRepository = userRepository;
    }
    public async Task<IActionResult> AddProduct()
    {
        List<ProductDto> existingProducts = [];
        List<Product> products = await productRepository.GetProducts();
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
        ProductsViewModel viewModel = new()
        {
            ExistingProducts = existingProducts
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductsViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            Product newProduct = new()
            {
                Name = viewModel.NewProduct.Name,
                UnitPrice = viewModel.NewProduct.UnitPrice,
                Quantity = viewModel.NewProduct.Quantity,
                Active = viewModel.NewProduct.Active
            };

            await productRepository.CreateProduct(newProduct);
            return RedirectToAction("AddProduct");
        }

        else
        {
            List<ProductDto> existingProducts = [];
            List<Product> products = await productRepository.GetProducts();
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

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(ProductsViewModel viewModel)
    {
        if(viewModel.Product is null){
            Console.WriteLine("product null");
        }
        int productId = viewModel.Product.Id;
        Console.WriteLine(productId);
        await productRepository.DeleteProduct(productId);
        return RedirectToAction("AddProduct");
    }

    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto userDto)
    {
        if (ModelState.IsValid)
        {
            User user = new()
            {
                Type = userDto.Type,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Mail = userDto.Mail,
                Password = userDto.Password
            };
            await userRepository.CreateUser(user);
            return RedirectToAction("CreateUser");
        }
        return View(userDto);
    }
}
