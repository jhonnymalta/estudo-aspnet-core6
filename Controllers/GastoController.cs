using estudo_aspnet_core6.Models;
using estudo_aspnet_core6.Services;
using Microsoft.AspNetCore.Mvc;

namespace estudo_aspnet_core6.Controllers
{

    public class GastoController : Controller
    {
       
    private readonly IRepository_Gastos repository_Gastos;
        public GastoController(IRepository_Gastos repository_Gastos)
        {
            this.repository_Gastos = repository_Gastos;
        }


        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Gasto gasto)
        {

            await repository_Gastos.Criar(gasto);
            return RedirectToAction("Index");
        }
    }
}
