using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TracsBusinessLogic;
using Tracs.Common.Enumeration;
using TRACSPortal.Areas.Accounting.Models;
using Tracs.Common.Models;
using Tracs.Common;
using Tracs.Common.ApiModels;

namespace TRACSPortal.Areas.Accounting.Services
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly ILogger<AccountingRepository> _logger;
        private IHostingEnvironment _evn;

        public AccountingRepository(IHostingEnvironment evn, ILogger<AccountingRepository> logger)
        {
            _logger = logger;
            _evn = evn;

        }

        public List<SelectListItem> GetBanks()
        {
            List<SelectListItem> banks = new List<SelectListItem>();
            
            try
            {
                banks = ConvertToSelectListItem(Accountings.GetBankList());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return banks;
        }

        public List<CaseModel> GetCasesByKeyword(string caseId)
        {
            List<CaseModel> cases = new List<CaseModel>();
            try
            {
                cases = Accountings.GetCasesByKeyword(caseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return cases;
        }
        public List<CaseModel> GetCasesByBankId(int bankId)
        {
            List<CaseModel> cases = new List<CaseModel>();
            try
            {
                cases = Accountings.GetCasesByBankId(bankId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return cases;
        }

        public List<CaseModel> GetCasesByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            List<CaseModel> cases = new List<CaseModel>();
            try
            {
                cases = Accountings.GetCasesByDateRange(dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return cases;
        }
        public CaseModel GetCaseByCaseId(string caseId)
        {
            CaseModel caseModel = new CaseModel();
            try
            {
                caseModel = Accountings.GetCaseByCaseId(caseId);
            }
            catch (Exception ex)
            {
                //logging
            }
            return caseModel;
        }
        public BillingInfoModel GetBillingById(string billingId)
        {
            BillingInfoModel billingInfoModel = new BillingInfoModel();
            try
            {
                billingInfoModel = Accountings.GetBillingDetailsById(billingId);
            }
            catch (Exception ex)
            {
                //logging
            }
            return billingInfoModel;
        }
        public PartModel GetPartDetailsByIds(string caseNumber, string serialNumber)
        {
            PartModel partModel = new PartModel();
            try
            {
                partModel = Accountings.GetPartDetailsByIds(caseNumber, serialNumber);
            }
            catch (Exception ex)
            {
                //logging
            }

            return partModel;
        }
        public ResponseResult SavePart(PartModel partModel)
        {
            ResponseResult result = Accountings.SavePart(partModel);

            return result;
        }
        public ResponseResult SaveBilling(AddBillApiModel billingInfoModel)
        {
            ResponseResult result = Accountings.SaveBilling(billingInfoModel);

            return result;
        }
        public ResponseResult AddRMANumberToCase(AddRMANumberApiModel addRMANumberApiModel)
        {
            ResponseResult result = Accountings.AddRMANumberToCase(addRMANumberApiModel);

            return result;
        }
        public ResponseResult DeleteBilling(string billingId)
        {
            ResponseResult result = Accountings.DeleteBilling(billingId);

            return result;
        }

        public void LogError(string errorMessage, string actionName)
        {
            Accountings.LogError(actionName + "\r\n" + errorMessage);
        }
        #region Private Functions
        private List<SelectListItem> ConvertToSelectListItem(List<BankModel> banks)
        {
            List<SelectListItem> listBank = new List<SelectListItem>();
            var li0 = new SelectListItem
            {
                Value = "",
                Text = "Choose bank ..."
            };
            listBank.Add(li0);
            foreach (BankModel bank in banks)
            {
                var li = new SelectListItem
                {
                    Value = bank.BankID.ToString(),
                    Text = bank.BankName
                };
                listBank.Add(li);
            }
            return listBank;
        }

        #endregion
    }

}
