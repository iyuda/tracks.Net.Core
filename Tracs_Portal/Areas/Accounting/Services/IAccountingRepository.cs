using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACSPortal.Areas.Accounting.Models;
using Tracs.Common.Models;
using Tracs.Common;
using Tracs.Common.ApiModels;

namespace TRACSPortal.Areas.Accounting.Services
{
    public interface IAccountingRepository
    {
        List<SelectListItem> GetBanks();
        List<CaseModel> GetCasesByKeyword(string caseId);
        List<CaseModel> GetCasesByBankId(int bankId);
        List<CaseModel> GetCasesByDateRange(DateTime dateFrom, DateTime dateTo);
        CaseModel GetCaseByCaseId(string caseId);
        BillingInfoModel GetBillingById(string invoiceId);
        PartModel GetPartDetailsByIds(string caseNumber, string serialNumber);
        ResponseResult SavePart(PartModel partModel);
        ResponseResult SaveBilling(AddBillApiModel billingInfoModel);
        ResponseResult AddRMANumberToCase(AddRMANumberApiModel addRMANumberApiModel);
        ResponseResult DeleteBilling(string billingId);
        void LogError(string errorMessage, string actionName);
    }
}
