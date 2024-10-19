using Microsoft.AspNetCore.Mvc;

namespace TechFarmSystem.Controllers
{
    public class DetalhesController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Dashboard/VerDetalhes.cshtml");
        }

        public IActionResult VerDetalhes()
        {
            return View("~/Views/Dashboard/VerDetalhes.cshtml");
        }
    }
}
