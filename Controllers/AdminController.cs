using Microsoft.AspNetCore.Mvc;
using salesAdmin.DTOs.Product;
using salesAdmin.DTOs.User;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;

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
    public IActionResult AddProduct()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            Product product = new()
            {
                Name = productDto.Name,
                UnitPrice = productDto.UnitPrice,
                Quantity = productDto.Quantity,
                Active = productDto.Active
            };

            await productRepository.CreateProduct(product);
            return RedirectToAction("AddProduct");
        }

        return View(productDto);
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
