using System.ComponentModel.DataAnnotations;

namespace estudo_aspnet_core6.Models
{
    public class TipoConta
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Nome é obrigatório!")]
        [StringLength(maximumLength:50,MinimumLength =3,ErrorMessage ="O nome do tipo de conta, deve ter no mínimo 3 e no máximo 50 caracteres!")]
        [Display(Name ="Nome para um tipo de conta:")]
        public string? Nome { get; set; }
        public int UsuarioId { get; set; }
        public int Ordem { get; set; }
    }
}
