using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ZagrosTestProject.ViewModels;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace ZagrosTestProject.Controllers
{
    public class AccountController : Controller
    {
        private Entities.ASPCoreDBContext _context;
        public AccountController(Entities.ASPCoreDBContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var hashPassowrd = Common.EncryptionUtility.HashSHA256(model.Password);
            var user = _context.Users.SingleOrDefault(q => q.UserName == model.UserName &&
            q.Password == hashPassowrd);
            if (user == null)
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نمی باشد ");
                return View(model);
            }
            var claims = new List<Claim>
{
new Claim(ClaimTypes.Name, user.UserName),
new Claim("FullName", $"{user.FirstName} {user.LastName}"),
//new Claim(ClaimTypes.Role, "Administrator"),
};
            var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A
                // value set here overrides the ExpireTimeSpan option of
                // CookieAuthenticationOptions set with AddCookie.
                //IsPersistent = true,
                // Whether the authentication session is persisted across
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.
                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.
                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http
                // redirect response value.
            };
            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}