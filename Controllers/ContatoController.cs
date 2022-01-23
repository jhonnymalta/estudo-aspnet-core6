using estudo_aspnet_core6.Models;
using Microsoft.AspNetCore.Mvc;

namespace estudo_aspnet_core6.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(Contato contato)
        {
            return RedirectToAction("Agradecimento");
        }

        public IActionResult Agradecimento() { return View(); }
    }
}
