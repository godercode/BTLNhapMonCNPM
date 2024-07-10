using BTLNhapMonCNPM.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTLNhapMonCNPM.Controllers;

public class DrinkController : Controller
{
    private readonly ApplicationContext _context;

    public DrinkController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Drinks.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<JsonResult> UploadAsync(IFormFile files)
    {
        string _targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");

        if (files == null || files.Length == 0)
        {
            ViewBag.Message = "File not selected";
            return Json(new
            {
                message = "uploaded failed",
            });

        }

        if (!Directory.Exists(_targetFilePath))
        {
            Directory.CreateDirectory(_targetFilePath);
        }

        var allowedFileTypes = new[] { "png", "jpg" };

        var fileExtension = Path.GetExtension(files.FileName).Substring(1);

        if (!allowedFileTypes.Contains(fileExtension))
        {
            return Json(new
            {
                message = "Invalid file type",
            });
        }


        var filePath = Path.Combine(_targetFilePath, files.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await files.CopyToAsync(stream);
        }


        return Json(new
        {
            url = $"Images/{files.FileName}",
            message = "uploaded successfully"
        });
    }
}