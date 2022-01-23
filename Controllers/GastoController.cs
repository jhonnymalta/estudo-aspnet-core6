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
        public  IActionResult NovoGasto(Gasto gasto)
        {
            if (!ModelState.IsValid)
            {
                return View(gasto);
            }
            return RedirectToAction("Index");
           
        }
    }
}
