using Dapper;
using estudo_aspnet_core6.Models;
using estudo_aspnet_core6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace estudo_aspnet_core6.Controllers
{
    public class TipoContaController : Controller
    {

       

        public  TipoContaController(IRepository_TipoConta repository_TipoConta)
        {
            Repository_TipoConta = repository_TipoConta;
        }

        public IRepository_TipoConta Repository_TipoConta { get; }

        public IActionResult Criar()
        {
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todosTiposContas = await Repository_TipoConta.GetAll();
            return View(todosTiposContas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(TipoConta tipoConta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoConta);
            }
            tipoConta.UsuarioId = 1;
            await Repository_TipoConta.Criar(tipoConta);

            return View();
        }

        
    }
}
