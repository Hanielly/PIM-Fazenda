using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using TechFarmSystem.Data;
using TechFarmSystem.Models;

namespace TechFarmSystem.Controllers
{
    public class ProducaoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProducaoController> _logger;

        public ProducaoController(AppDbContext context, ILogger<ProducaoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                _logger.LogInformation("Carregando lista de produções");
                var producoes = _context.Producao.ToList();
                return View(producoes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar as produções");
                ViewBag.ErrorMessage = "Ocorreu um erro ao carregar as produções: " + ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("Abrindo tela de criação de produção");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producao producao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Tentando salvar a produção: {@Producao}", producao);
                    _context.Producao.Add(producao);
                    int result = _context.SaveChanges();

                    if (result > 0)
                    {
                        _logger.LogInformation("Produção adicionada com sucesso: {@Producao}", producao);
                        _logger.LogInformation("Redirecionando para a página Index");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning("Nenhuma linha foi afetada ao tentar salvar a produção.");
                        ViewBag.ErrorMessage = "Nenhuma alteração foi feita no banco de dados.";
                    }
                }
                else
                {
                    _logger.LogWarning("Erro de validação ao criar a produção: {@ModelStateErrors}", ModelState.Values.SelectMany(v => v.Errors));
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br/>";
                    }
                }
                return View(producao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar a produção");
                ViewBag.ErrorMessage = "Ocorreu um erro ao criar a produção: " + ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                _logger.LogInformation("Carregando produção para edição: ID = {Id}", id);
                var producao = _context.Producao.Find(id);
                if (producao == null)
                {
                    return NotFound();
                }
                return View(producao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar a produção para edição");
                ViewBag.ErrorMessage = "Ocorreu um erro ao carregar a produção para edição: " + ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(Producao producao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Tentando editar a produção: {@Producao}", producao);
                    _context.Producao.Update(producao);
                    int result = _context.SaveChanges();

                    if (result > 0)
                    {
                        _logger.LogInformation("Produção editada com sucesso: {@Producao}", producao);
                        _logger.LogInformation("Redirecionando para a página Index");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning("Nenhuma linha foi afetada ao tentar editar a produção.");
                        ViewBag.ErrorMessage = "Nenhuma alteração foi feita no banco de dados.";
                    }
                }
                else
                {
                    _logger.LogWarning("Erro de validação ao editar a produção: {@ModelStateErrors}", ModelState.Values.SelectMany(v => v.Errors));
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br/>";
                    }
                }
                return View(producao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar as alterações na produção");
                ViewBag.ErrorMessage = "Ocorreu um erro ao salvar as alterações na produção: " + ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("Carregando produção para exclusão: ID = {Id}", id);
                var producao = _context.Producao.Find(id);
                if (producao == null)
                {
                    return NotFound();
                }
                return View(producao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar a produção para exclusão");
                ViewBag.ErrorMessage = "Ocorreu um erro ao carregar a produção para exclusão: " + ex.Message;
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _logger.LogInformation("Confirmando exclusão da produção: ID = {Id}", id);
                var producao = _context.Producao.Find(id);
                if (producao == null)
                {
                    return NotFound();
                }
                _context.Producao.Remove(producao);
                int result = _context.SaveChanges();

                if (result > 0)
                {
                    _logger.LogInformation("Produção excluída com sucesso: {@Producao}", producao);
                    _logger.LogInformation("Redirecionando para a página Index");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogWarning("Nenhuma linha foi afetada ao tentar excluir a produção.");
                    ViewBag.ErrorMessage = "Nenhuma alteração foi feita no banco de dados.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir a produção");
                ViewBag.ErrorMessage = "Ocorreu um erro ao excluir a produção: " + ex.Message;
                return View("Error");
            }
        }
    }
}
