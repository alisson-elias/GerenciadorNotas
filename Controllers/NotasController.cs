using Microsoft.AspNetCore.Mvc;
using GerenciadorNotas.Services;
using GerenciadorNotas.ViewModels;

namespace GerenciadorNotas.Controllers
{
    public class NotasController : Controller
    {        
        private readonly NotaService _service;

        public NotasController(NotaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notas = _service.ObterTodos();
            return View(notas);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(NovaNotaViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            _service.Adicionar(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
