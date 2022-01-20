using System.ComponentModel.DataAnnotations;

namespace estudo_aspnet_core6.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="O campo e-mail é Obrigatório ")]
        [EmailAddress(ErrorMessage ="O campo e-mail deve ser um endereço de e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="O campo password é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
