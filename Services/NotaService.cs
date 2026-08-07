using GerenciadorNotas.ViewModels;
using GerenciadorNotas.Models;

namespace GerenciadorNotas.Services
{
    public class NotaService 
    {
        private readonly List<Nota> _nota = new();
        private int _proximoId = 1;

        public List<Nota> ObterTodos() => _nota;

        public void Adicionar(NovaNotaViewModel vm)
        {
            _nota.Add(new Nota
            {
                Id = _proximoId++,
                Titulo = vm.Titulo,
                Conteudo = vm.Conteudo,
                DataCriacao = DateTime.Now,
            });
        }
    }
}
