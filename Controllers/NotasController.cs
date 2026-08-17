using Microsoft.AspNetCore.Mvc;
using GerenciadorNotas.Services;
using GerenciadorNotas.ViewModels;

namespace GerenciadorNotas.Controllers
{
    public class NotasController : Controller
    {
        private readonly INotaService _notaservice;

        public NotasController(INotaService notaService)
        {
            _notaservice = notaService;
        }

        public IActionResult Index()
        {
            var nota = _notaservice.Listar();
            return View(nota);
        }

        public IActionResult Detalhes(int id)
        {
            var nota = _notaservice.ObterPorId(id);

            if (nota is null)
                return NotFound();

            return View(nota);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(NovaNotaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _notaservice.Adicionar(model);
            TempData["Mensagem"] = "Nota cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var nota = _notaservice.ObterPorId(id);

            if (nota is null)
                return NotFound();

            var model = new EditarNotaViewModel
            {
                Id = nota.Id,
                Titulo = nota.Titulo,
                Conteudo = nota.Conteudo,
               
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EditarNotaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var atualizado = _notaservice.Atualizar(model);

            if (!atualizado)
                return NotFound();

            TempData["Mensagem"] = "Nota atualizada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var nota = _notaservice.ObterPorId(id);

            if (nota is null)
                return NotFound();

            return View(nota);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id)
        {
            var removido = _notaservice.Remover(id);

            if (!removido)
                return NotFound();

            TempData["Mensagem"] = "Nota excluída com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        //    private readonly NotaService _notaservice;

        //    public NotasController(NotaService service)
        //    {
        //        _service = service;
        //    }

        //    [HttpGet]
        //    public IActionResult Index()
        //    {
        //        var notas = _service.ObterTodos();
        //        return View(notas);
        //    }

        //    [HttpGet]
        //    public IActionResult Cadastrar()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Cadastrar(NovaNotaViewModel vm)
        //    {
        //        if (!ModelState.IsValid)
        //            return View(vm);

        //        _service.Adicionar(vm);
        //        return RedirectToAction(nameof(Index));
        //    }
        //}
    }
}
