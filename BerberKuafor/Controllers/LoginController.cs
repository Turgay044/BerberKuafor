using BerberKuafor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Security.Claims;

namespace BerberKuafor.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(Admin a)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciMail == a.KullaniciMail && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, a.KullaniciMail)
        };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                // Başarılı girişten sonra yönlendirme
                return RedirectToAction("Index", "Personel");
            }
            ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
            return View();
        }
    }
}
