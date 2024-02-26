using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using EntityLayer.Concrete;
using System.Linq;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Policy;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                bool isLogin = false; 
                var user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.UserPassword == model.UserPassword);

                if (user != null)
                {
                    // Kullanıcıyı oturum açık olarak işaretle
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName),
                        new Claim(ClaimTypes.Name, user.UserPassword)
                        // Buraya isteğe bağlı olarak ek bilgiler ekleyebilirsiniz
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true // İsteğe bağlı olarak kalıcı bir oturum açabilirsiniz
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    isLogin = true;
                    // Başarılı giriş, belirli bir sayfaya yönlendir
                    return RedirectToAction("Index", "About");
                }
            }

            // Geçersiz giriş, hata ekleyerek giriş sayfasını tekrar göster
            ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            return View("Index", model);
        }
    }
}