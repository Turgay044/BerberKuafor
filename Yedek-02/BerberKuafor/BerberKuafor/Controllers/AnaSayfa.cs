using Microsoft.AspNetCore.Mvc;

namespace BerberKuafor.Controllers
{
    public class AnaSayfa : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Servisler()
        {
            return View();
        }

        public IActionResult Galeri()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }
    }
}
