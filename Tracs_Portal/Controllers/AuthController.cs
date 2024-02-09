using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRACSPortal.Models;

namespace TRACSPortal.Controllers
{
        [Route("auth")]
        public class AuthController : Controller
        {
            [Route("login")]
            public IActionResult LogIn()
            {
                return View(new LogInModel());
            }

            [Route("login")]
            [ValidateAntiForgeryToken]
            [HttpPost]
            public async Task<IActionResult> LogIn(LogInModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //var user = await userService.Authenticate(model.Email, model.Password);
                User user = new User(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("InvalidCredentials", "Could not validate your credentials");
                    return View(model);
                }

            HttpContext.Session.SetString("UserName", user.Username?.ToString());
            // Create the identity from the user info
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            // You can add roles to use role-based authorization
            // identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            // Authenticate using the identity
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

    }

}