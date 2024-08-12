using Microsoft.AspNetCore.Mvc;
using salesAdmin.Data;
using salesAdmin.DTOs.Sale;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;

namespace salesAdmin.Controllers;

public class SalesController : Controller
{
    private readonly ISaleRepository saleRepository;
    public SalesController(ISaleRepository saleRepository)
    {
        this.saleRepository = saleRepository;
    }

    public IActionResult CreateRequest()
    {
        return View();
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
