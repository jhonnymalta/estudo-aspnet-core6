using estudo_aspnet_core6.Models;
using Microsoft.AspNetCore.Mvc;

namespace estudo_aspnet_core6.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Perfil()
        {
            var persona = new Perfil()
            {
                Nome = "Jota Landes",
                Email = "jotalandes@jotalandes.com.br",
                Telefone = "9999-9999",
                Matricula = "jl-1254"

            };

            return View(persona);
        }
    }
}
