using BTLNhapMonCNPM.Data;
using BTLNhapMonCNPM.Models;
using BTLNhapMonCNPM.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace BTLNhapMonCNPM.Controllers;

public class DrinkController : Controller
{
    private readonly ApplicationContext _context;

    public IActionResult Edit(int ID)
    {
        var drink = _context.Drinks.Include(_drink => _drink.Category)
            .Include(_drink => _drink.Images)
            .FirstOrDefault(d => d.Id == ID);

        var categories = _context.Categories.ToList();

        var model = new DrinkCategoriesViewModel { Categories = categories, Drink = drink };

        return View(model);
    }

    [HttpPost]
    public async Task<JsonResult> EditAsync(IFormCollection formData)
    {
        try
        {

            if (!int.TryParse(formData["id"], out int id))
            {
                throw new ArgumentException("Id is required");
            }

            var drink = _context.Drinks.Include(_drink => _drink.Images).FirstOrDefault(d => d.Id == id);

            if (drink == null)
            {
                throw new InvalidOperationException("Drink not found");
            }

            if (string.IsNullOrWhiteSpace(formData["name"].ToString()))
            {
                throw new ArgumentException("Name is required.");
            }

            drink.Name = formData["name"].ToString();

            if (!double.TryParse(formData["price"], out double price) || price <= 0)
            {
                throw new ArgumentException("Price must be a positive number.");
            }

            drink.Price = price;

            if (!double.TryParse(formData["comparePrice"], out double comparedPrice) || comparedPrice <= 0)
            {
                throw new ArgumentException("Compared Price must be a positive number.");
            }

            drink.ComparedPrice = comparedPrice;

            if (string.IsNullOrWhiteSpace(formData["description"].ToString()))
            {
                throw new ArgumentException("Description is required.");
            }

            drink.Description = formData["description"].ToString();

            var imageUrls = formData["images"];
            if (imageUrls.Count == 0)
            {
                throw new ArgumentException("At least one image is required.");
            }

            if (int.TryParse(formData["categoryId"], out int categoryId) && categoryId > 0 && _context.Categories.FirstOrDefault(_c => _c.Id == categoryId) != null)
            {
                drink.CategoryId = categoryId;
            }
            else
            {
                throw new ArgumentException("Category Id is required.");
            }

            Dictionary<int, DrinkImage> imagesDict = new Dictionary<int, DrinkImage>();

            foreach (var image in drink.Images)
            {
                imagesDict.Add((int)image.Id, image);
            }

            foreach (var item in imageUrls)
            {
                if (string.IsNullOrWhiteSpace(item.ToString()))
                {
                    throw new ArgumentException("Image URL cannot be empty.");
                }

                var parts = item.ToString().Split(" ");

                if (parts.Length > 1)
                {
                    var imageId = int.Parse(parts[1]);
                    if (imagesDict[imageId] == null)
                    {
                        throw new ArgumentException("Id Image not found.");
                    }

                    imagesDict.Remove(imageId);
                }
                else
                {
                    drink.Images.Add(new DrinkImage { Url = item.ToString(), DrinkId = (int)drink.Id });
                }
            }

            foreach (var image in imagesDict.Values)
            {
                _context.DrinkImages.Remove(image);
            }

            await _context.SaveChangesAsync();

            return Json(new { message = "updated successfully" });
        }
        catch (ArgumentException ex)
        {
            return Json(new { message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        var drink = await _context.Drinks.FindAsync(id);
        if (drink != null)
        {
            _context.Drinks.Remove(drink);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    public DrinkController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var drinks = _context.Drinks.Include(_drink => _drink.Images).ToList();
        foreach (var drink in drinks)
        {
            Console.WriteLine("image");
            Console.WriteLine(drink.Images);
        }
        return View(drinks);
    }

    public IActionResult Create()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
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

        var allowedFileTypes = new[] { "png", "jpg", "jpeg" };

        var fileExtension = Path.GetExtension(files.FileName).Substring(1);

        if (!allowedFileTypes.Contains(fileExtension))
        {
            return Json(new
            {
                message = "Invalid file type",
            });
        }

        var fileName = files.FileName.Replace(" ", "");

        var filePath = Path.Combine(_targetFilePath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await files.CopyToAsync(stream);
        }

        return Json(new
        {
            url = $"/Images/{fileName}",
            message = "uploaded successfully"
        });
    }

    [HttpPost]
    public async Task<JsonResult> CreateAsync(IFormCollection formData)
    {
        Drink drink = new Drink();

        try
        {
            if (string.IsNullOrWhiteSpace(formData["name"].ToString()))
            {
                throw new ArgumentException("Name is required.");
            }

            drink.Name = formData["name"].ToString();

            if (!double.TryParse(formData["price"], out double price) || price <= 0)
            {
                throw new ArgumentException("Price must be a positive number.");
            }

            drink.Price = price;

            if (!double.TryParse(formData["comparePrice"], out double comparedPrice) || comparedPrice <= 0)
            {
                throw new ArgumentException("Compared Price must be a positive number.");
            }

            drink.ComparedPrice = comparedPrice;

            if (string.IsNullOrWhiteSpace(formData["description"].ToString()))
            {
                throw new ArgumentException("Description is required.");
            }

            drink.Description = formData["description"].ToString();

            var imageUrls = formData["images"];
            if (imageUrls.Count == 0)
            {
                throw new ArgumentException("At least one image is required.");
            }

            if (int.TryParse(formData["categoryId"], out int categoryId) && categoryId > 0 && _context.Categories.FirstOrDefault(_c => _c.Id == categoryId) != null)
            {
                drink.CategoryId = categoryId;
            }
            else
            {
                throw new ArgumentException("Category Id is required.");
            }


            foreach (var item in imageUrls)
            {
                if (string.IsNullOrWhiteSpace(item.ToString()))
                {
                    throw new ArgumentException("Image URL cannot be empty.");
                }

                drink.Images.Add(new DrinkImage { Url = item.ToString() });
            }
        }
        catch (ArgumentException ex)
        {
            return Json(new { message = ex.Message });
        }

        _context.Drinks.Add(drink);
        await _context.SaveChangesAsync();

        foreach (var image in drink.Images)
        {
            image.DrinkId = drink.Id.Value;
        }

        await _context.SaveChangesAsync();

        return Json(new { message = "created successfully" });
    }
}