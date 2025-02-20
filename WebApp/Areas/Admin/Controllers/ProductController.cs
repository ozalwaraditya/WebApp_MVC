using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace WebApp.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        public ProductController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
