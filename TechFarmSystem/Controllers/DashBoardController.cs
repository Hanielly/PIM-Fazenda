using Microsoft.AspNetCore.Mvc;

namespace TechFarmSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult PainelIndicadores()
        {
            return View();
        }
    }
}
