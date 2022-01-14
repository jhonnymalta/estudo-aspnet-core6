namespace estudo_aspnet_core6.Models
{
    public class IndeceContasViewModel
    {
        public string TipoConta { get; set; }
        public IEnumerable<Contas> contas { get; set; }
       
    }
}
