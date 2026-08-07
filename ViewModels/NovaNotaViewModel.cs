using System.ComponentModel.DataAnnotations;

namespace GerenciadorNotas.ViewModels
{
    public class NovaNotaViewModel
    {
        [Required(ErrorMessage = "Informe o título.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o conteúdo.")]
        public string Conteudo { get; set; } = string.Empty;       
    }
}
