using BTLNhapMonCNPM.Data;
using BTLNhapMonCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace BTLNhapMonCNPM.Controllers;

public class BuyController : Controller
{
    private readonly ApplicationContext _context;

    public BuyController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var drinks = _context.Drinks.Include(_drink => _drink.Images).ToList();
        return View(drinks);
    }


    [HttpPost]
    public async Task<JsonResult> BuyNowAsync(IFormCollection formData)
    {
        Bill bill = new Bill();

        var drinkId = Convert.ToInt64(formData["id"]);

        var quantity = Convert.ToInt64(formData["quantity"]);

        var drink = _context.Drinks.FirstOrDefault(_d => _d.Id == drinkId);

        if (drink == null)
        {
            return Json(new { message = "Drink not found" });
        }

        bill.Total = quantity * drink.Price;
        bill.ComparedTotal = quantity * drink.ComparedPrice;

        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        bill.BillDetails.Add(new BillDetail { BillId = bill.Id, Quantity = (int)quantity, DrinkId = (int)drink.Id, SubTotal = bill.Total, SubTotalCompared = bill.ComparedTotal });
        await _context.SaveChangesAsync();


        return Json(new
        {
            message = "purchased successfully",
            billId = bill.Id,
        });
    }
}