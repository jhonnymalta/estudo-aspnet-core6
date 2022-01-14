using System.ComponentModel.DataAnnotations;

namespace estudo_aspnet_core6.Models
{
    public class Contas
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório")]
        [StringLength(maximumLength:50,ErrorMessage = " Campo nome pode conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name ="Tipo Conta")]
        public int TipoContaId { get; set; }
        public decimal Balance { get; set; }

        [StringLength(maximumLength:150,ErrorMessage ="Utilize no máximo 150 caracteres.")]
        public string Descricao { get; set; }

        public string TipoConta { get; set; }
    }
}
