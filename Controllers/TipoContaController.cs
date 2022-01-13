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

            return RedirectToAction("Index");   
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuarioId = 1;
            var tipoConta = await Repository_TipoConta.GetByID(id,usuarioId);

            if(tipoConta == null)
            {
                return RedirectToAction("Não Encontrado", "Home");

            }
            return View(tipoConta);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(TipoConta tipoConta)
        {
           var usuarioId = 1;
           await Repository_TipoConta.Atualizar(tipoConta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            var usuarioId = 1;
            var tipoConta = await Repository_TipoConta.GetByID(id,usuarioId);

            if (tipoConta == null)
            {
                return RedirectToAction("Não Encontrado", "Home");
            }
            return View(tipoConta);

        }
        [HttpPost]
        public  async Task<IActionResult> DeletarTipoConta(int id)
        {
            var usuarioId = 1;
            var tipoConta = await Repository_TipoConta.GetByID(id, usuarioId);

            if (tipoConta == null)
            {
                return RedirectToAction("Não Encontrado", "Home");
            }
            await Repository_TipoConta.Deletar(id);
            return RedirectToAction("Index");
        }

        
    }
}
