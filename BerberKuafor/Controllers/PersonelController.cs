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

        [HttpGet]
        public IActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel P)
        {
            c.Personels.Add(P);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
