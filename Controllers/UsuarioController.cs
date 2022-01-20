using estudo_aspnet_core6.Models;
using Microsoft.AspNetCore.Mvc;

namespace estudo_aspnet_core6.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            return RedirectToAction("Index", "Transacoes");
        }
    }
}
