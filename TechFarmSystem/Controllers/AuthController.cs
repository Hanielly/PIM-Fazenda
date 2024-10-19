using Microsoft.AspNetCore.Mvc;
using TechFarmSystem.Data;
using TechFarmSystem.Models;
using System.Linq;

namespace TechFarmSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Funcionarios.FirstOrDefault(u => u.Email == email && u.Senha == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Menu");
            }

            TempData["ErrorMessage"] = "Email ou senha inválidos";
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View("AccCreate");
        }

        [HttpPost]
        public IActionResult Register(Funcionario funcionario)
        {
            if (funcionario.Senha.Length < 6)
            {
                TempData["ErrorMessage"] = "A senha deve ter no mínimo 6 caracteres.";
                return View("AccCreate", funcionario);
            }

            var temAdmin = _context.Funcionarios.Any(u => u.NivelAcesso == "admin");
            funcionario.NivelAcesso = temAdmin ? "usuario" : "admin";

            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    string innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    TempData["ErrorMessage"] = "Erro ao salvar a conta: " + innerExceptionMessage;
                    return View("AccCreate", funcionario);
                }

                var savedUser = _context.Funcionarios.FirstOrDefault(u => u.Email == funcionario.Email);
                if (savedUser != null)
                {
                    TempData["SuccessMessage"] = "Conta criada com sucesso!";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["ErrorMessage"] = "Erro ao salvar a conta.";
                    return View("AccCreate", funcionario);
                }
            }

            TempData["ErrorMessage"] = "Erro ao criar conta. Tente novamente.";
            return View("AccCreate", funcionario);
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string email)
        {
            var user = _context.Funcionarios.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                TempData["Message"] = "Um email foi enviado para redefinir sua senha.";
            }
            else
            {
                TempData["ErrorMessage"] = "Email não encontrado";
            }

            return View();
        }
    }
}
