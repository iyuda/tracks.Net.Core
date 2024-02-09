using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tracs.Common.Models;
using TRACSPortal.Areas.Accounting.Models;
using TRACSPortal.Areas.Accounting.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace TRACSPortal.Areas.Accounting.Controllers
{
    [Area("Accounting")]
    [RedirectingAction]
    public class HomeController : Controller
    {
        private IAccountingRepository _accountingRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public HomeController(IAccountingRepository accountingRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _accountingRepository = accountingRepository;
            _services = services;
            _evn = evn;
        }

        public IActionResult Index(SearchModel searchModel)
        {
            //if (HttpContext.Session.GetString("Token") == null)
            //{
            //    return RedirectToAction("Index", "Home", new { area = "Login" });
            //}
            AccountingHomeViewModel accountingHomeViewModel = new AccountingHomeViewModel();
            try
            {
                var request = HttpContext.Request;
                TracsBusinessLogic.ApiHelper.UserInfo = request.Headers["User-Agent"];

                if (_services == null) throw new ArgumentNullException(nameof(_services));
                
                accountingHomeViewModel.Banks = _accountingRepository.GetBanks();
                if (searchModel != null)
                {
                    switch (searchModel.SelectedRadioSearch)
                    {
                        case "1":
                            accountingHomeViewModel.CaseList = _accountingRepository.GetCasesByKeyword(searchModel.SearchKeyWord);
                            break;
                        case "2":
                            accountingHomeViewModel.CaseList = _accountingRepository.GetCasesByBankId(searchModel.SelectedBankId);
                            break;
                        case "3":
                            accountingHomeViewModel.CaseList = _accountingRepository.GetCasesByDateRange(searchModel.FromDate, searchModel.ToDate);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "HomeController-Index");
            }
            return View(accountingHomeViewModel);
        }
        public IActionResult GetCaseList(AccountingHomeViewModel vm)
        {
            string caseId = "";
            int bankId = 0;
            DateTime dateFrom;
            DateTime dateTo;

            ViewBag.SelectedSearchBy = vm.SelectedRadioSearch;
            vm.Banks = _accountingRepository.GetBanks();

            switch (vm.SelectedRadioSearch)
            {
                case "1":
                    caseId = vm.SearchKeyWord;
                    vm.CaseList = _accountingRepository.GetCasesByKeyword(caseId);
                    break;
                case "2":
                    bankId = vm.SelectedBankId;
                    vm.CaseList = _accountingRepository.GetCasesByBankId(bankId);
                    break;
                case "3":
                    dateFrom = vm.FromDate;
                    dateTo = vm.ToDate;
                    vm.CaseList = _accountingRepository.GetCasesByDateRange(dateFrom, dateTo);
                    break;
                default:
                    break;
            }

            return PartialView("_CaseListHome", vm);
        }

    }

}