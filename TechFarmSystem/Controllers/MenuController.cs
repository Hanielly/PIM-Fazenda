using Microsoft.AspNetCore.Mvc;

namespace TechFarmSystem.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Index.cshtml"); 
        }
    }
}
