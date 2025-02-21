using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Repository;
using Web.Models;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public ProductController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Product.GetAll().ToList();
            if (TempData["success"] != null)
            {
                TempData["success"] = TempData["success"];
            }
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            if (id != null && id != 0)
            {
                var product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(product);
            }
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Upsert(Product Model)
        {
            if (Model.Id == 0)
            {
                TempData["success"] = "Category Added Successfully!!!";
                _unitOfWork.Product.Add(Model);
            }
            else
            {
                TempData["success"] = "Category Updated Successfully!!!";
                _unitOfWork.Product.Update(Model);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != 0)
            {
                var category = _unitOfWork.Product.Get(u => u.Id == id);
                return View(category);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Category model)
        {
            _unitOfWork.Category.Delete(model);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
