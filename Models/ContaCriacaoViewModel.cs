using Microsoft.AspNetCore.Mvc.Rendering;

namespace estudo_aspnet_core6.Models
{
    public class ContaCriacaoViewModel : Contas
    {
        public IEnumerable<SelectListItem> TipoConta { get; set; }
    }
}
