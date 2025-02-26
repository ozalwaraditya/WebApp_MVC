using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Data.Repository;
using Web.Models;
using Web.Models.ViewModels;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            if (TempData["success"] != null)
            {
                TempData["success"] = TempData["success"];
            }
            return View(categories);
        }


        //Upsert = Update + Insert

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                CategoryList = CategoryList
            };

            if (id != null && id != 0)
            {
                var product = _unitOfWork.Product.Get(u => u.Id == id);
                productVM.Product = product;  
            }

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM model, IFormFile? file)
        {

            if (ModelState.IsValid) {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(model.Product.ImageUrl))
                    {
                        // Delete the old image
                        var oldImageUrl = Path.Combine(wwwRootPath, model.Product.ImageUrl.Trim('\\'));

                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }
                    }


                    using(var fileStream = new FileStream(Path.Combine(productPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.Product.ImageUrl = @"\images\product\" + fileName;
                }


                if (model.Product.Id == 0)
                {
                    TempData["success"] = "Category Added Successfully!!!";
                    _unitOfWork.Product.Add(model.Product);
                }
                else
                {
                    TempData["success"] = "Category Updated Successfully!!!";
                    _unitOfWork.Product.Update(model.Product);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {

                model.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(model);

            }


        }

        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                CategoryList = CategoryList
            };

            if (id != 0)
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(ProductVM model)
        {
            _unitOfWork.Product.Delete(model.Product);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
