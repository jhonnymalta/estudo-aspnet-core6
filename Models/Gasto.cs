namespace estudo_aspnet_core6.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal  Valor { get; set; }
        public DateTime DiaGasto { get; set; }
    }
}
