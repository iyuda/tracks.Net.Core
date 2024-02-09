using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TRACSPortal.Areas.RMATech.Controllers
{
    [Area("RMATech")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}