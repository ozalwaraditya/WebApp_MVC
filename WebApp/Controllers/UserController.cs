using Microsoft.AspNetCore.Mvc;
using Web.Data.Data;
using Web.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (model.Name == model.Email)   //This is custom validation conditions
            {
                ModelState.AddModelError("Name", "User Name cannot be email!!!");
            }

            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();
                TempData["success"] = "Category Added successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        
        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (model.Name == model.Email)   //This is custom validation conditions
            {
                ModelState.AddModelError("Name", "User Name cannot be email!!!");
            }

            _context.Users.Update(model);
            _context.SaveChanges();
            TempData["success"] = "Category Updated successfully";

            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(User model)
        {
            _context.Users.Remove(model);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
