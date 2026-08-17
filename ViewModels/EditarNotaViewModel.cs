using System.ComponentModel.DataAnnotations;

namespace GerenciadorNotas.ViewModels
{
    public class EditarNotaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o Conteudo.")]
        public string Conteudo { get; set; } = string.Empty;

       
    }
}
