using Microsoft.AspNetCore.Mvc;

namespace estudo_aspnet_core6.Controllers
{
    public class TransacoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Semanal()
        {
            return View();
        }

        public IActionResult Mensal()
        {
            return View();
        }

        public IActionResult ExcelReport()
        {
            return View();
        }

        public IActionResult Calendario()
        {
            return View();
        }
    }
}
