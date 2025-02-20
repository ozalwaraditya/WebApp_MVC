using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Data;
using Web.Models;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            if (TempData["success"] != null)
            {
                TempData["success"] = TempData["success"];
            }
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            if(id != null && id != 0)
            {
                var category = _context.Categories.FirstOrDefault(u=>u.Id == id);
                return View(category);
            }
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Upsert(Category Model)
        {
            if(Model.Id == 0)
            {
                TempData["success"] = "Category Added Successfully!!!";
                _context.Categories.Add(Model);
            }
            else
            {
                TempData["success"] = "Category Updated Successfully!!!";
                _context.Categories.Update(Model);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != 0)
            {
                var category = _context.Categories.FirstOrDefault(u => u.Id == id);
                return View(category);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Category model)
        {
            _context.Categories.Remove(model);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted Successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
