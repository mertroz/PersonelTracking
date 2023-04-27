using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.WebApp.Models;
using System.Security.Claims;

namespace PersonnelTrackingSystem.WebApp.Controllers
{

    [Authorize(Roles = "Admin")] //Sadece "Admin" rolüne sahip kullanıcılar bu sayfaya erişebilir.
    public class AccountController : Controller
    {
        UserService _userService = new UserService();
        RoleService _roleService = new RoleService();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginRequest)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Login(loginRequest.Username, loginRequest.Password);
                if (user!=null)
                {
                    var role=_roleService.GetById(user.RoleId);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.EmployeeId.ToString()),
                        new Claim(ClaimTypes.Name, loginRequest.Username),
                        new Claim(ClaimTypes.Role, role.Name)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                new ClaimsPrincipal(claimsIdentity),
                                                authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Kullanıcı Adı veya Şifre Yanlış !");
                }
            }


            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        //[HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Logout()
        //    {
        //        await HttpContext.SignOutAsync();
        //        return RedirectToAction("Login");
        //    }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
