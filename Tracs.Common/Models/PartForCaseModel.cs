using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tracs.Common.Models
{
    public class PartForCaseModel
    {
        public string PartNumber { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Part Description")]
        public string PartDescription { get; set; }

        [Display(Name = "Part Family")]
        public string PartFamily { get; set; }

        [Display(Name = "Test Result")]
        public string TestResultDescription { get; set; }

        [Display(Name = "Billing Id")]
        public string BillingId { get; set; }

        [Display(Name = "Warranty Status")]
        public string WarrantyStatus { get; set; }

        [Display(Name = "Complain Confirmed")]
        public bool IsConfirmed { get; set; }

        [Display(Name = "Signed To Billing")]
        public bool IsSignToBilling { get; set; }
        public bool IsSignToBillingPre { get; set; }
    }
}
