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
using TRACSPortal.Areas.Shipping.Services;
using Microsoft.AspNetCore.Routing;

namespace TRACSPortal.Areas.Shipping.Controllers
{
    [Area("Shipping")]
    [RedirectingAction]
    public class HomeController : Controller
    {
        private IShippingRepository _shippingRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public HomeController(IShippingRepository productShippingRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _shippingRepository = productShippingRepository;
            _services = services;
            _evn = evn;
        }
        #region Get Views
        public IActionResult Index()
        {
            ViewBag.Title = "RMA Shipping";
            ViewBag.LoadPageErrors = HttpContext.Session.GetString("LoadPageErrors")?.ToString();
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            return View();
        }

        public ActionResult FilterColumn(string ListType)
        {
            ViewBag.ListType = ListType;
            return PartialView();


        }

        public ActionResult ShipList(string SearchColumn = null, string SearchValue = null)
        {
            ViewBag.SearchColumn = SearchColumn;
            ViewBag.SearchValue = SearchValue;
            var lstShipping = _shippingRepository.GetShipList(SearchColumn, SearchValue);
            return PartialView(lstShipping);

        }
        public ActionResult ReceiveList(string SearchColumn = null, string SearchValue = null)
        {
            ViewBag.SearchColumn = SearchColumn;
            ViewBag.SearchValue = SearchValue;
            var lstRecveiving = _shippingRepository.GetReceiveList(SearchColumn, SearchValue);
            return PartialView(lstRecveiving);

        }
        public JsonResult ShipItem(string RmaID, string TrackingNumber)
        {
            object anonymous = _shippingRepository.ShipItem(RmaID, TrackingNumber);
            RouteValueDictionary rvd = new RouteValueDictionary(anonymous);
            return Json(new { status = rvd["status"], message = rvd["message"] });
        }
        public JsonResult ReceiveItem(string RmaID)
        {
            object anonymous = _shippingRepository.ReceiveItem(RmaID);
            RouteValueDictionary rvd = new RouteValueDictionary(anonymous);
            return Json(new { status = rvd["status"], message = rvd["message"] });
        }
        public ActionResult ShippingUserProfileGet(bool ShippingProfile = false)
        {
            HttpContext.Session.SetString("LoadPageErrors", "");
            string UserId = HttpContext.Session.GetString("UserId")?.ToString();
            UserProfileModel userModel = TracsBusinessLogic.Shipping.GetUserProfile(UserId);

            userModel.UserId = UserId;
            userModel.Password = HttpContext.Session.GetString("Password")?.ToString();
            ViewBag.NoLayout = true;
            ViewBag.LoadPageErrors = HttpContext.Session.GetString("LoadPageErrors")?.ToString();
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            return View("ShippingUserProfile", userModel);
        }
        #endregion

        #region post data

        #endregion



    }

}
