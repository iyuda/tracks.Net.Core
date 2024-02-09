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

namespace TRACSPortal.Areas.Login.Controllers
{
    [Area("Login")]

    public class PasswordResetController : Controller
    {
        private ILoginRepository _loginRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public PasswordResetController(ILoginRepository loginRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _loginRepository = loginRepository;
            _services = services;
            _evn = evn;
        }
        #region Get Views
        public IActionResult Index()
        {
            
            ViewBag.NoLayout = true;
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            return View();
        }
        public IActionResult ValidateEmail()
        {
            ViewBag.NoLayout = true;
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            return View();
        }
        #endregion

        #region post data
        [HttpPost]
        public ActionResult PasswordResetUpdate()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            string Password = Request.Form["Password"];

            string jsonString = _loginRepository.PasswordResetUpdate(UserId, Password);
            return Content(jsonString, "application/json");

        }
        [HttpPost]
        public ActionResult ValidateEmailUpdate()
        {
            string Email = Request.Form["email"];

            string jsonString = _loginRepository.ValidateEmailUpdate(Email);
            TempData["Email"] = Email;
            TempData["TempPassword"] = true;
            TempData["Password"] = "";
            return Content(jsonString, "application/json");

        }
        #endregion



    }

}
