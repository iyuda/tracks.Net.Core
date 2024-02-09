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
using Microsoft.AspNetCore.Routing;

using TRACSPortal.Areas.Login.Services;
using System.Net.Http;
using System.Net;

namespace TRACSPortal.Areas.Login.Controllers
{
    [Area("Login")]

    public class RegistrationController : Controller
    {
        private ILoginRepository _loginRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public RegistrationController(ILoginRepository loginRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _loginRepository = loginRepository;
            _services = services;
            _evn = evn;
        }
        #region Get Views
        public IActionResult Index()
        {

            UserRegistrationModel model = new UserRegistrationModel() { Firms = _loginRepository.GetFirms() };
            model.Countries = _loginRepository.GetCountries();
            ViewBag.NoLayout = true;
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            return View(model);
        }
        public IActionResult VerifyCode()
        {
            ViewBag.Email = TempData["Email"];
            ViewBag.UserId = TempData["UserId"];
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            return View();
        }
        #endregion

        #region post data
        [HttpPost]
        public ActionResult UserRegistrationUpdate(UserRegistrationModel model)
        {
            string jsonString = _loginRepository.UserRegistrationUpdate(model);
            TempData["Email"] = model.Email;
            TempData["Password"] = model.Password;
            TempData["UserId"] = JObject.Parse(jsonString)?["data"]?[0]["UserId"]?.ToString();
            return Content(jsonString, "application/json");
        }
        [HttpPost]
        public ActionResult VerifyCodeUpdate()
        {

            string UserId = Request.Form["UserId"];
            string VerificationCode = Request.Form["VerificationCode"];
            TempData["Email"] = Request.Form["Email"].ToString();
            string jsonString = _loginRepository.VerifyCodeUpdate(UserId, VerificationCode);
            return Content(jsonString, "application/json");
            
        }
        #endregion
        public ActionResult ResendCode()
        {
            string UserId = Request.Form["UserId"];
            string jsonString = _loginRepository.ResendCode(UserId);
            return Content(jsonString, "application/json");
        }


    }

}
