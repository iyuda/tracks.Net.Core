using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tracs.Common;
using Tracs.Common.Models;
using TRACSPortal.Areas.Accounting.Models;
using TRACSPortal.Areas.Accounting.Services;

namespace TRACSPortal.Areas.Accounting.Controllers
{
    [Area("Accounting")]
    [RedirectingAction]
    public class PartController : Controller
    {
        private IAccountingRepository _accountingRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public PartController(IAccountingRepository accountingRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _accountingRepository = accountingRepository;
            _services = services;
            _evn = evn;
        }
        public IActionResult Index(AccountingCaseViewModel vm)
        {
            //GetPartDetails
            AccountingPartViewModel accountingPartViewModel = new AccountingPartViewModel();
            try
            {
                accountingPartViewModel.SelectedPart = _accountingRepository.GetPartDetailsByIds(vm.CaseNumber, vm.SelectedSerialNumber);
                if (accountingPartViewModel.SelectedPart != null && accountingPartViewModel.SelectedPart.WarrantyInfo != null)
                    accountingPartViewModel.SelectedWarrantyStatus = accountingPartViewModel.SelectedPart.WarrantyInfo.WarrantyStatus == Tracs.Common.Enumeration.enWarrantyStatus.Within ? "1" : "2";
                accountingPartViewModel.CaseNumber = vm.CaseNumber;
                accountingPartViewModel.CurrentSearchModel = vm.CurrentSearchModel;
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "PartController-Index");
            }
            return View(accountingPartViewModel);
        }

        public IActionResult SavePart(AccountingPartViewModel vm)
        {
            AccountingCaseViewModel vmCase = new AccountingCaseViewModel();
            try
            {
                vmCase.CaseNumber = vm.CaseNumber;
                vmCase.CurrentSearchModel = vm.CurrentSearchModel;

                PartModel partModel = new PartModel();
                partModel.CaseId = vm.CaseNumber;
                partModel.SerialNumber = vm.SelectedPart.SerialNumber;
                partModel.ReplacementSerialNumber = vm.SelectedPart.ReplacementSerialNumber;
                partModel.IsFullWarranty = vm.SelectedWarrantyStatus == "1" ? true : false;
                partModel.Observations = vm.SelectedPart.Observations;

                ResponseResult result = _accountingRepository.SavePart(partModel);
                if (result.IsSuccess)
                {
                    AccountingHomeViewModel mode = VMPartToVMHome(vm);
                    return RedirectToAction("Index", "Case", mode);
                }
                else
                {
                    vm.ErrorUpdatePart = result.ResultMessage;
                }
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "PartController-SavePart");
                vm.ErrorUpdatePart = ex.Message;
            }
            return View("Index", vm);
        }

        public IActionResult GoBackToCase(AccountingPartViewModel vm)
        {
            AccountingHomeViewModel mode = VMPartToVMHome(vm);
            return RedirectToAction("Index", "Case", mode);
        }
        public IActionResult GoBackToHome(AccountingPartViewModel vm)
        {
            return RedirectToAction("Index", "Home", vm.CurrentSearchModel);
        }


        #region Private Functions
        private AccountingHomeViewModel VMPartToVMHome(AccountingPartViewModel vm)
        {
            AccountingHomeViewModel mode = new AccountingHomeViewModel();
            mode.SelectedCaseId = vm.CaseNumber;
            mode.SelectedRadioSearch = vm.CurrentSearchModel.SelectedRadioSearch;
            mode.SearchKeyWord = vm.CurrentSearchModel.SearchKeyWord;
            mode.SelectedBankId = vm.CurrentSearchModel.SelectedBankId;
            mode.FromDate = vm.CurrentSearchModel.FromDate;
            mode.ToDate = vm.CurrentSearchModel.ToDate;
            return mode;
        }
        #endregion
    }
}