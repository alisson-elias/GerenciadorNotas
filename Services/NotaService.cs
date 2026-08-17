using GerenciadorNotas.Models;
using GerenciadorNotas.ViewModels;

namespace GerenciadorNotas.Services
{
    public class NotaService : INotaService
    {
        private readonly List<Nota> _nota =
    [
        new Nota
        {
            Id = 1,
            Titulo = "Português",
            Conteudo = "palavras palavras palavras palavras.",
            DataCriacao = DateTime.Now,

        },
        new Nota
        {
            Id = 2,
            Titulo = "Matemática",
            Conteudo = "números números números números.",
           DataCriacao = DateTime.Now,

        }
    ];

        public List<Nota> Listar()
        {
            return _nota.ToList();
        }

        public Nota? ObterPorId(int id)
        {
            return _nota.FirstOrDefault(nota => nota.Id == id);
        }

        public void Adicionar(NovaNotaViewModel model)
        {
            var novaNota = new Nota
            {
                Id = GerarNovoId(),
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                DataCriacao = DateTime.Now

            };

            _nota.Add(novaNota);
        }

        public bool Atualizar(EditarNotaViewModel model)
        {
            var nota = ObterPorId(model.Id);

            if (nota is null)
                return false;

            nota.Titulo = model.Titulo;
            nota.Conteudo = model.Conteudo;           

            return true;
        }

        public bool Remover(int id)
        {
            var nota = ObterPorId(id);

            if (nota is null)
                return false;

            _nota.Remove(nota);
            return true;
        }

        private int GerarNovoId()
        {
            return _nota.Count == 0 ? 1 : _nota.Max(nota => nota.Id) + 1;
        }
        //private readonly List<Nota> _nota = new();
        //private int _proximoId = 1;

        //public List<Nota> ObterTodos() => _nota;

        //public void Adicionar(NovaNotaViewModel vm)
        //{
        //    _nota.Add(new Nota
        //    {
        //        Id = _proximoId++,
        //        Titulo = vm.Titulo,
        //        Conteudo = vm.Conteudo,
        //        DataCriacao = DateTime.Now,
        //    });
        //}
    }
}
