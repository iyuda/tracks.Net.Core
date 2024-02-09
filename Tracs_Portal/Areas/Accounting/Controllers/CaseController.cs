using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Tracs.Common;
using Tracs.Common.Models;
using Tracs.Common.ApiModels;
using TRACSPortal.Areas.Accounting.Models;
using TRACSPortal.Areas.Accounting.Services;
using Microsoft.Extensions.Logging;

namespace TRACSPortal.Areas.Accounting.Controllers
{
    [Area("Accounting")]
    [RedirectingAction]
    public class CaseController : Controller
    {
        private IAccountingRepository _accountingRepository;
        private IServiceProvider _services;
        private IHostingEnvironment _evn;

        public CaseController(IAccountingRepository accountingRepository, IServiceProvider services, IHostingEnvironment evn)
        {
            _accountingRepository = accountingRepository;
            _services = services;
            _evn = evn;
        }

        public IActionResult Index(AccountingHomeViewModel vm)
        {
            AccountingCaseViewModel accountingCaseViewModel = new AccountingCaseViewModel();
            try
            {
                accountingCaseViewModel.CaseRouting = Request.Path.Value.Substring(1);
                accountingCaseViewModel.CaseNumber = vm.SelectedCaseId;
                accountingCaseViewModel.SelectedCase = _accountingRepository.GetCaseByCaseId(vm.SelectedCaseId);

                SearchModel currentSearchModel = new SearchModel();
                currentSearchModel.SelectedRadioSearch = vm.SelectedRadioSearch;
                if (vm.SelectedRadioSearch != null)
                {
                    switch (vm.SelectedRadioSearch)
                    {
                        case "1":
                            currentSearchModel.SearchKeyWord = vm.SearchKeyWord;
                            break;
                        case "2":
                            currentSearchModel.SelectedBankId = vm.SelectedBankId;
                            break;
                        case "3":
                            currentSearchModel.FromDate = vm.FromDate;
                            currentSearchModel.ToDate = vm.ToDate;
                            break;
                        default:
                            break;
                    }
                }
                accountingCaseViewModel.CurrentSearchModel = currentSearchModel;

                List<PartForCaseModel> listPartAll = accountingCaseViewModel.SelectedCase.PartListForAddBilling;

                accountingCaseViewModel.SelectedPartsForAdd = accountingCaseViewModel.SelectedCase.PartListForAddBilling;
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "CaseController-Index");
            }
            return View(accountingCaseViewModel);
        }
      
        public IActionResult GetBillingDetails(AccountingCaseViewModel vm)
        {
            vm.SelectedBilling = _accountingRepository.GetBillingById(vm.SelectedBillingId);
            return PartialView("_CaseBillingEdit", vm);
        }
        public IActionResult ShowAddBilling(AccountingCaseViewModel vm)
        {
            vm.SelectedCase = _accountingRepository.GetCaseByCaseId(vm.CaseNumber);
            return PartialView("_CaseBillingAdd", vm);
        }
        public IActionResult BackFromPart(AccountingCaseViewModel vm)
        {
            AccountingCaseViewModel accountingCaseViewModel = new AccountingCaseViewModel();
            accountingCaseViewModel.CaseNumber = vm.CaseNumber;
            accountingCaseViewModel.SelectedCase = _accountingRepository.GetCaseByCaseId(vm.CaseNumber);
            accountingCaseViewModel.CurrentSearchModel = vm.CurrentSearchModel;
            return View("Index", accountingCaseViewModel);
        }

        public IActionResult AddBilling(AccountingCaseViewModel vm)
        {
            AccountingCaseViewModel accountingCaseViewModel = new AccountingCaseViewModel();
            try
            {
                AddBillApiModel addBillApiModel = new AddBillApiModel();
                addBillApiModel.InvoiceNumber = vm.NewBilling.InvoiceNumber;
                addBillApiModel.PoOrderNumber = vm.NewBilling.PoOrderNumber;
                addBillApiModel.SalesOrderNumber = vm.NewBilling.SalesOrderNumber;
                addBillApiModel.CaseId = vm.CaseNumber;
                addBillApiModel.ClientRefused = vm.NewBilling.ClientRefused;

                List<PartForAddBillApiModel> selectedParts = new List<PartForAddBillApiModel>();
                foreach (PartForCaseModel item in vm.SelectedCase.PartListForAddBilling)
                {
                    if (item.IsSignToBilling)
                    {
                        PartForAddBillApiModel part = new PartForAddBillApiModel();
                        part.PartNumber = item.PartNumber;
                        part.SerialNumber = item.SerialNumber;
                        selectedParts.Add(part);
                    }
                }
                addBillApiModel.AddParts = selectedParts;
                ResponseResult result = _accountingRepository.SaveBilling(addBillApiModel);
                if (result.IsSuccess)
                {
                    accountingCaseViewModel.CaseNumber = vm.CaseNumber;
                    accountingCaseViewModel.SelectedCase = _accountingRepository.GetCaseByCaseId(vm.CaseNumber);

                    AccountingHomeViewModel vm1 = new AccountingHomeViewModel();
                    vm1.SelectedCaseId = vm.CaseNumber;
                    vm1.SelectedRadioSearch = vm.CurrentSearchModel.SelectedRadioSearch;
                    vm1.SearchKeyWord = vm.CurrentSearchModel.SearchKeyWord;
                    vm1.SelectedBankId = vm.CurrentSearchModel.SelectedBankId;
                    vm1.FromDate = vm.CurrentSearchModel.FromDate;
                    vm1.ToDate = vm.CurrentSearchModel.ToDate;
                    return RedirectToAction("Index", "Case", vm1);
                }
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "CaseController-AddBilling");
            }
            return View("Index", accountingCaseViewModel);
        }

        public IActionResult SaveBilling(AccountingCaseViewModel vm)
        {
            BillingInfoModel billingModel = new BillingInfoModel();
            AddBillApiModel addBillApiModel = new AddBillApiModel();
            addBillApiModel.InvoiceNumber = vm.SelectedBilling.InvoiceNumber;
            addBillApiModel.PoOrderNumber = vm.SelectedBilling.PoOrderNumber;
            addBillApiModel.SalesOrderNumber = vm.SelectedBilling.SalesOrderNumber;
            addBillApiModel.CaseId = vm.SelectedBilling.RMANumber;
            addBillApiModel.ClientRefused = vm.SelectedBilling.ClientRefused;
            addBillApiModel.BillingId = vm.SelectedBilling.BillingId;
            AccountingHomeViewModel vm1 = new AccountingHomeViewModel();
            vm1.SelectedCaseId = vm.SelectedBilling.RMANumber;
            vm1.SelectedRadioSearch = vm.CurrentSearchModel.SelectedRadioSearch;
            vm1.SearchKeyWord = vm.CurrentSearchModel.SearchKeyWord;
            vm1.SelectedBankId = vm.CurrentSearchModel.SelectedBankId;
            vm1.FromDate = vm.CurrentSearchModel.FromDate;
            vm1.ToDate = vm.CurrentSearchModel.ToDate;

            AccountingCaseViewModel accountingCaseViewModel = new AccountingCaseViewModel();
            try
            {
                List<PartForAddBillApiModel> selectedParts = new List<PartForAddBillApiModel>();
                List<PartForAddBillApiModel> unselectedParts = new List<PartForAddBillApiModel>();

                foreach (PartForCaseModel item in vm.SelectedBilling.PartListForBilling)
                {
                    PartForAddBillApiModel part = new PartForAddBillApiModel();
                    part.PartNumber = item.PartNumber;
                    part.SerialNumber = item.SerialNumber;

                    if (item.IsSignToBilling)
                    {
                        if (!item.IsSignToBillingPre)
                            selectedParts.Add(part);
                    }
                    else
                    {
                        if (item.IsSignToBillingPre)
                            unselectedParts.Add(part);
                    }
                }
                if (vm.SelectedPartsForAdd != null && vm.SelectedPartsForAdd.Count > 0)
                {
                    foreach (PartForCaseModel itemForAdd in vm.SelectedPartsForAdd)
                    {
                        if (itemForAdd.IsSignToBilling)
                        {
                            PartForAddBillApiModel part = new PartForAddBillApiModel();
                            part.PartNumber = itemForAdd.PartNumber;
                            part.SerialNumber = itemForAdd.SerialNumber;
                            selectedParts.Add(part);
                        }
                    }
                }
                addBillApiModel.AddParts = selectedParts;
                addBillApiModel.DeleteParts = unselectedParts;

                ResponseResult result = _accountingRepository.SaveBilling(addBillApiModel);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index", "Case", vm1);
                }
                else
                {
                    accountingCaseViewModel.ErrorManageBilling = result.ResultMessage;
                    return PartialView("_CaseBillingEdit", accountingCaseViewModel);
                }
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "CaseController-SaveBilling");
                accountingCaseViewModel.ErrorManageBilling = "There was an error processing your request, please try later.";
                return RedirectToAction("Index", "Case", vm1);
            }
        }
        public IActionResult AddRMANumber(string caseid, string id)
        {
            AccountingCaseViewModel accountingCaseViewModel = new AccountingCaseViewModel();
            AddRMANumberApiModel addRMANumberApiModel = new AddRMANumberApiModel();
            addRMANumberApiModel.CaseId = caseid;
            addRMANumberApiModel.RMANumber = id;
            ResponseResult result = _accountingRepository.AddRMANumberToCase(addRMANumberApiModel);

            accountingCaseViewModel.CaseNumber = caseid;
            accountingCaseViewModel.SelectedCase = _accountingRepository.GetCaseByCaseId(caseid);
            return PartialView("_CaseRMAInfo", accountingCaseViewModel);
        }
        public IActionResult GoBackToHome(AccountingCaseViewModel vm)
        {
            return RedirectToAction("Index", "Home", vm.CurrentSearchModel);
        }
        public IActionResult DeleteBilling(string id)
        {
            AccountingCaseViewModel accountingCaseViewModel = new AccountingCaseViewModel();
            try
            {
                string[] ids = id.Split("~");
                string billingId = ids[0];
                string invoiceId = ids[1];
                string caseId = ids[2];

                //TODO: Delete Billing
                ResponseResult result = _accountingRepository.DeleteBilling(billingId);

                accountingCaseViewModel.CaseNumber = caseId;
                accountingCaseViewModel.SelectedCase = _accountingRepository.GetCaseByCaseId(caseId);
                List<PartForCaseModel> listPartAll = accountingCaseViewModel.SelectedCase.PartListForAddBilling;

                accountingCaseViewModel.SelectedPartsForAdd = accountingCaseViewModel.SelectedCase.PartListForAddBilling;
                BillingInfoModel bill = new BillingInfoModel();
                bill.PartListForBilling = listPartAll;
                accountingCaseViewModel.SelectedBilling = bill;
            }
            catch (Exception ex)
            {
                _accountingRepository.LogError(ex.Message, "CaseController-DeleteBilling");
            }
            return PartialView("_CaseBillingList", accountingCaseViewModel);
        }


    }
}