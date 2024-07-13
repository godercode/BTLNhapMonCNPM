using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTLNhapMonCNPM.Models;
using BTLNhapMonCNPM.Data;
using Microsoft.EntityFrameworkCore;

namespace BTLNhapMonCNPM.Controllers;

public class BillController : Controller
{
    private readonly ApplicationContext _context;

    public BillController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var bills = _context.Bills.ToList();

        return View(bills);
    }

    public IActionResult Detail(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bill = _context.Bills.Include("BillDetails.Drink").FirstOrDefault(_d => _d.Id == id);

        if (bill == null)
        {
            return NotFound();
        }

        return View(bill);
    }
}
