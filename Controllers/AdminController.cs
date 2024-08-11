using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> AddProduct(Product product){
        if(!ModelState.IsValid){
            return View(product);
        }
        await productRepository.CreateProduct(product);
        return RedirectToAction("AddProduct");
    }

    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user){
        if(!ModelState.IsValid){
            return View(user);
        }
        await userRepository.CreateUser(user);
        return RedirectToAction("CreateUser");
    }
}
