using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tracs.Common.Models;
using Microsoft.AspNetCore.Http;
using TracsBusinessLogic;
using Wangkanai.Detection;
using TRACSPortal.Models;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;

namespace TRACSPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return RedirectToAction("Index", "Home",new { area = "Login" });
            }
            ViewBag.PopupUserProfile = TempData["PopupUserProfile"];
            return View();
        }
        public ActionResult ShowUserProfile()
        {
            TempData["PopupUserProfile"] = true;

            return RedirectToAction("Index", "Home");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        public ActionResult PasswordChangeGet()
        {
            ViewBag.NoLayout = true;
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            ViewBag.CurrentPassword= HttpContext.Session.GetString("Password")?.ToString();
            return View("PasswordChange");
        }
        public ActionResult PasswordChangeUpdate()
        {
            string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                { "UserId", HttpContext.Session.GetString("UserId")?.ToString() },
                                                { "CurrentPassword", Request.Form["txtCurrentPassword"] },
                                                { "NewPassword", Request.Form["txtNewPassword"] }});
            Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_ChangePassword, "POST", data: postData);
            HttpResponseMessage objResponseMsg = response.Item1;
            string strResponseMsg = response.Item2;
            if (objResponseMsg.StatusCode != HttpStatusCode.OK)
            {
                var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                if (String.IsNullOrEmpty(message))
                    message = "There was an error processing your request";
                return Json(new { status = 0, message = message });
            }
            else
            {
                var status = JObject.Parse(strResponseMsg)?["status"]?.ToString() ?? "0";
                if (int.Parse(status) == 1) HttpContext.Session.SetString("Password", Request.Form["txtNewPassword"]);
                return Content(strResponseMsg, "application/json");
            }
        }
        public ActionResult UserProfileGet(bool IsTechnician=false)
        {
            HttpContext.Session.SetString("LoadPageErrors", "");
            string UserId = HttpContext.Session.GetString("UserId")?.ToString();
            //if (String.IsNullOrEmpty(UserId)) return null;
            UserProfileModel userModel = CommonFunctions.GetUserProfile(UserId);

            userModel.UserId = UserId;
            userModel.Password = HttpContext.Session.GetString("Password")?.ToString();
            ViewBag.NoLayout = true;
            ViewBag.LoadPageErrors = HttpContext.Session.GetString("LoadPageErrors")?.ToString();
            ViewBag.IsMobile = Request.Device().Type == DeviceType.Mobile;
            if (!IsTechnician)
                return View("UserProfile", userModel);
            else
                return View("TechnicianUserProfile", userModel);
        }

        public JsonResult GetStatesByCountryJson(int countryId)
        {
            List<StateModel> states = CommonFunctions.GetStatesByCountry(countryId.ToString());
            return Json(states.Select(x => new { id = x.StateId, name = x.Name }).ToList());
        }
        [HttpPost]
        public  ActionResult UserProfileUpdate(UserProfileModel model)
        {

            bool apiError = false;
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_UpdateProfile, "PUT", data: JsonConvert.SerializeObject(model));


                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    var status = JObject.Parse(strResponseMsg)?["status"]?.ToString() ?? "0";
                    if (int.Parse(status) == 1)
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        JToken jsonToken = data?[0];
                        UserModel user = jsonToken?.ToObject<UserModel>();
                        user.id = int.Parse(jsonToken?["UserId"].ToString());
                        HttpContext.Session.SetString("UserId", user.id?.ToString());

                        HttpContext.Session.SetString("UserId", user.id?.ToString());
                        HttpContext.Session.SetString("UserName", user.Name?.ToString());
                        HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));


                        HttpContext.Session.SetString("FirmTypeId", jsonToken?["FirmTypeId"]?.ToString());

                        HttpContext.Session.SetString("Email", model.Email);
                        HttpContext.Session.SetString("Phone", model.Phone);
                        HttpContext.Session.SetString("FirmName", user.FirmName);
                        HttpContext.Session.SetString("FirmId", model.FirmId);

                    }
                    return Content(strResponseMsg, "application/json");
                    //return Json(new { status = 0, message = "test"  }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return Json(new { status = 0, message = Logger.GetProperErrorMessage(ex.Message, apiError) });
            }
        }
        [HttpPost]
        public ActionResult UpdateDefaultAddress(UserProfileModel model)
        {
            bool apiError = false;
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_UpdateReturnAddress, "PUT", data: JsonConvert.SerializeObject(model));

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    var status = JObject.Parse(strResponseMsg)?["status"]?.ToString() ?? "0";
                    return Content(strResponseMsg, "application/json");
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return Json(new { status = 0, message = Logger.GetProperErrorMessage(ex.Message, apiError) });
            }
        }

    }
}
