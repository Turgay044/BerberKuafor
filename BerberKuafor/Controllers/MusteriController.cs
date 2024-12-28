using BerberKuafor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniMusteri(Musteri M)
        {
            c.Musteriler.Add(M);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MusteriSil(int ID)
        {
            var Rem = c.Musteriler.Find(ID);
            c.Musteriler.Remove(Rem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MusteriGetir(int id)
        {
            var mstr = c.Musteriler.Find(id);
            return View("MusteriGetir", mstr);
        }
        public IActionResult MusteriGuncelle()
        {
            return RedirectToAction("Index");
        }

        [HttpPost("update")]
        public IActionResult MusteriGuncelle(Musteri m)
        {
            var pers = c.Musteriler.Find(m.IdMusteri);
            pers.MusteriAdi = m.MusteriAdi;
            pers.MusteriSoyadi = m.MusteriSoyadi;
            pers.MusteriMail = m.MusteriMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
