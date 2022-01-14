using estudo_aspnet_core6.Models;
using estudo_aspnet_core6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace estudo_aspnet_core6.Controllers
{
    public class ContasController: Controller
    {
       
        private readonly IRepository_TipoConta repostiorioTipoConta;
        private readonly IRepository_conta repository_Conta;

        public ContasController(IRepository_TipoConta repostiorioTipoConta, IRepository_conta repository_Conta)
        {
            this.repostiorioTipoConta = repostiorioTipoConta;
            this.repository_Conta = repository_Conta;
        }

       [HttpGet]
       public async Task<IActionResult> Criar()
        {
            var tipoConta = await repostiorioTipoConta.GetAll();
            var modelo = new ContaCriacaoViewModel();
            modelo.TipoConta = tipoConta.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));

            return View(modelo);
        }
        [HttpPost]
          public async Task<IActionResult> Criar(ContaCriacaoViewModel conta)
        {
            var usuarioId = 1;
            var tipoConta = await repostiorioTipoConta.GetByID(conta.TipoContaId,usuarioId);

            if(tipoConta == null)
            {
                return RedirectToAction("NãoEncontrado", "Home");
            }
           await repository_Conta.Criar(conta);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contasComTipoConta = await repository_Conta.GetAll();
            return View(contasComTipoConta);
        }

    

    }
}
