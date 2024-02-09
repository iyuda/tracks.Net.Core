using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.ApiModels;

namespace Tracs.Common.Models
{
    public class BillingInfoModel
    {
        [Display(Name = "Billing Id")]
        public string BillingId { get; set; }

        [Display(Name = "RMA Number")]
        public string RMANumber { get; set; }

        [Display(Name = "PO Number")]
        public string PoOrderNumber { get; set; }

        [Display(Name = "Sale OrderNumber")]
        public string SalesOrderNumber { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Refuse To Purchase")]
        public bool ClientRefused { get; set; }

        [Display(Name = "Billing Status")]
        public string BillingStatus { get; set; }

        public List<PartForCaseModel> PartListForBilling { get; set; }
        public string SeletedParts { get; set; }

    }
}
