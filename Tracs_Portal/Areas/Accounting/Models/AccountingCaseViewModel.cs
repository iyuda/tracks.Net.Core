using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Models;

namespace TRACSPortal.Areas.Accounting.Models
{
    public class AccountingCaseViewModel
    {
        public string CaseNumber { get; set; }
        public string CaseRouting { get; set; }
        public CaseModel SelectedCase { get; set; }
        public PartModel SelectedPart { get; set; }
        public BillingInfoModel SelectedBilling { get; set; }

        public string SelectedInvoiceNumber { get; set; }
        public CaseModel SelectedCaseFor { get; set; }
        public string SelectedSerialNumber { get; set; }
        public string SelectedBillingId { get; set; }

        public List<PartForCaseModel> SelectedPartsForAdd { get; set; }
        public BillingInfoModel NewBilling { get; set; }

        public SearchModel CurrentSearchModel { get; set; }

        public string ErrorManageBilling { get; set; }
    }
}
