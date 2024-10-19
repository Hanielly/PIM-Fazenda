using Microsoft.AspNetCore.Mvc;
using TechFarmSystem.Data;
using TechFarmSystem.Models;

namespace TechFarmSystem.Controllers
{
    public class FuncionarioController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public IActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
    }
}
