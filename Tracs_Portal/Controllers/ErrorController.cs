using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tracs.Common.Models;
using Microsoft.AspNetCore.Http;
using TracsBusinessLogic;
using Wangkanai.Detection;
using TRACSPortal.Models;
using System.Diagnostics;
using System.Text;

namespace TRACSPortal.Controllers
{
    public class ErrorController : Controller
    {

        [HttpPost]
        public EmptyResult JSErrorHandler()
        {
            StringBuilder errorMsg = new StringBuilder();
            var msg = Request.Form["msg"];
            if (!String.IsNullOrEmpty(msg))
            {
                errorMsg.Append("Message: ");
                errorMsg.Append(msg);
                errorMsg.Append(Environment.NewLine);
            }
            var url = Request.Form["url"];
            if (!String.IsNullOrEmpty(url))
            {
                errorMsg.Append("URL: ");
                errorMsg.Append(url);
                errorMsg.Append(Environment.NewLine);
            }
            var line = Request.Form["line"];
            if (!String.IsNullOrEmpty(line))
            {
                errorMsg.Append("Line: ");
                errorMsg.Append(line);
                errorMsg.Append(Environment.NewLine);
            }
            Logger.LogActivity(errorMsg.ToString(), "JS Errors");
            return null;
            
        }
    }
}