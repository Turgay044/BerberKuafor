using Microsoft.AspNetCore.Mvc;
using BerberKuafor.Models;

namespace BerberKuafor.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Personels.ToList();

            return View(degerler);
        }
    }
}
