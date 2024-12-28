using Microsoft.AspNetCore.Mvc;
using BerberKuafor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BerberKuafor.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        [Authorize]
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
        public IActionResult PersonelSil(int ID)
        {
            var Rem = c.Personels.Find(ID);
            c.Personels.Remove(Rem);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult PersonelGetir(int id)
        {
            var prsl = c.Personels.Find(id);
            return View("PersonelGetir", prsl);
        }

        public IActionResult PersonelGuncelle()
        {
            return RedirectToAction("Index");
        }

        [HttpPost("update")]
        public IActionResult PersonelGuncelle(Personel p)
        {
            var pers = c.Personels.Find(p.IDPersonel);
            pers.PersonelAdi = p.PersonelAdi;
            pers.PersonelSoyad = p.PersonelSoyad;
            c.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}
