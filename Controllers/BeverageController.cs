using BTLNhapMonCNPM.Models;
using BTLNhapMonCNPM.Repositories;
using Microsoft.AspNetCore.Mvc;
using static BTLNhapMonCNPM.Repositories.IBeverageRepositorys;

namespace BTLNhapMonCNPM.Controllers
{
    public class BeverageController : Controller
    {
        private readonly IBeverageRepository _beverageRepository;

        public BeverageController(IBeverageRepository beverageRepository)
        {
            _beverageRepository = beverageRepository;
        }

        public IActionResult Index()
        {
            var beverages = _beverageRepository.GetAll();
            return View(beverages);
        }

        public IActionResult Details(int id)
        {
            var beverage = _beverageRepository.GetById(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                _beverageRepository.Add(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        public IActionResult Edit(int id)
        {
            var beverage = _beverageRepository.GetById(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        [HttpPost]
        public IActionResult Edit(Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                _beverageRepository.Update(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        public IActionResult Delete(int id)
        {
            var beverage = _beverageRepository.GetById(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _beverageRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
