using System.ComponentModel.DataAnnotations;

namespace estudo_aspnet_core6.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public decimal  Valor { get; set; }
        public DateTime DiaGasto { get; set; }
    }
}
