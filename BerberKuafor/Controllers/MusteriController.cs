using BerberKuafor.Models;
using Microsoft.AspNetCore.Mvc;

namespace BerberKuafor.Controllers
{
    public class MusteriController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Musteriler.ToList();
            return View(degerler);
        }
    }
}
