using estudo_aspnet_core6.Models;
using estudo_aspnet_core6.Services;
using Microsoft.AspNetCore.Mvc;
namespace estudo_aspnet_core6.Controllers
{
    public class ContasController: Controller
    {
       
        private readonly IRepository_TipoConta repostiorioTipoConta;

        public ContasController(IRepository_TipoConta repostiorioTipoConta)
        {
            this.repostiorioTipoConta = repostiorioTipoConta;
        }

       

        [HttpGet]
        

    }
}
