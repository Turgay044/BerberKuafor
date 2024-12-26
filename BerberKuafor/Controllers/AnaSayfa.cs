using Microsoft.AspNetCore.Mvc;
using BerberKuafor.Models;

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

        public IActionResult Personel()
        {
            var prsl = new List<Personel>()
            {
                new Personel()
                {
                    IDPersonel = 1, PersonelAdi="Ahmet", PersonelSoyad="Kabak"
                },
                new Personel()
                {
                    IDPersonel = 2, PersonelAdi="Ayşe", PersonelSoyad="Çetin"
                },
                new Personel()
                {
                    IDPersonel = 3, PersonelAdi="Mehmet", PersonelSoyad="Sağlam"
                }
            };
            return View(prsl);
        }

        public IActionResult PersoneLayout()
        {
            return View();
        }

        public IActionResult PersonelDosyasi()
        {
            return View();
        }
    }
}
