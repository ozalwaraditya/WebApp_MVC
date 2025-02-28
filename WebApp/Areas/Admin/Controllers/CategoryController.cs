using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Data;
using Web.Data.Repository;
using Web.Models;
using WebApp.Utility;

namespace WebApp.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]                              //Only Admin Can Access this page
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public CategoryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll().ToList();
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
                var category = _unitOfWork.Category.Get(u => u.Id == id);
                return View(category);
            }
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Upsert(Category Model)
        {
            if (Model.Id == 0)
            {
                TempData["success"] = "Category Added Successfully!!!";
                _unitOfWork.Category.Add(Model);
            }
            else
            {
                TempData["success"] = "Category Updated Successfully!!!";
                _unitOfWork.Category.Update(Model);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != 0)
            {
                var category = _unitOfWork.Category.Get(u => u.Id == id);
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
