using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tracs.Common.Models;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Wangkanai.Detection;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TracsBusinessLogic;
using System.Threading;
using TRACSPortal.Areas.Login.Services;
using Microsoft.AspNetCore.Routing;

namespace TRACSPortal.Areas.Login.Controllers
{
    [Area("Login")]

    public class HomeController : Controller
    {
        private ILoginRepository _loginRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public HomeController(ILoginRepository loginRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _loginRepository = loginRepository;
            _services = services;
            _evn = evn;
        }
        #region Get Views
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var returnValue = _loginRepository.ValidateLogin(model);
                if (returnValue.GetType().Name == "UserModel")
                {
                    UserModel user = returnValue;
                    switch (user.PasswordTypeId.ToString())
                    {
                        case "1":
                            HttpContext.Session.SetString("UserId", user.id?.ToString());
                            if (_loginRepository.GetReturnAddresses(user.id?.ToString()).Count == 0)
                            {
                                ViewBag.PopupAddress = true;
                                model.Countries = _loginRepository.GetCountries();
                                return View(model);
                            }
                            else
                                return RedirectToAction("Index", "PasswordReset");
                        case "2":
                            HttpContext.Session.SetString("UserId", user.id?.ToString());
                            return RedirectToAction("Index", "PasswordReset");
                        case "5":
                            TempData["Email"] = user.Email;
                            TempData["UserId"] = user.id?.ToString();
                            return RedirectToAction("VerifyCode", "Registration");
                        default:
                            HttpContext.Session.SetString("UserId", user.id?.ToString());
                            HttpContext.Session.SetString("Password", model.Password);
                            HttpContext.Session.SetString("IsTechnician", "1");
                            return RedirectToAction("Index", "Home", new { area = "" });

                            //    if ((user.FirmTypeId ?? "").ToString().ToLower() != "3")

                            //{
                            //    ViewBag.NoLayout = true;
                            //    return RedirectToAction("Index", "Home", new { area = "" });
                            //}
                            //else
                            //{
                            //    ViewBag.Title = user.FirmName;
                            //    return RedirectToAction("Securitas", "Home");
                            //    //return View("~/Views/Home/Securitas.cshtml");
                            //}

                    }
                }
                else
                    ViewBag.ErrorMsg = returnValue;
            }
                
                ViewBag.LoginFailed = true;
                ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
                return View("Index", model);
        }
        public ActionResult Index(string Email = null)
        {

            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            ViewBag.NoLayout = true;
            ViewBag.TempPassword = !String.IsNullOrEmpty(TempData["TempPassword"]?.ToString());
            ViewBag.ErrorMsg = TempData["ErrorMsg"];
            ViewBag.LoginFailed = (ViewBag.ErrorMsg ?? "") != "";
            if (Email == null)
                Email = TempData["Email"]?.ToString();
            if (Email == null)
                return View();
            else
            {
                string Password = TempData["Password"]?.ToString();
                return View(new LoginModel() { Email = Email, Password = Password });
            }
        }
        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }


        #endregion

        #region post data
        [HttpPost]
        public JsonResult SubmitReturnAddress(ReturnAddressModel model)
        {
            var response = _loginRepository.SubmitReturnAddress(model);
            return Json(response);
        }
        #endregion



    }

}
