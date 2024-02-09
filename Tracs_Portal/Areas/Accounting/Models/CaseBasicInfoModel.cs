using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Enumeration;

namespace TRACSPortal.Areas.Accounting.Models
{
    public class CaseBasicInfoModel
    {
        public string CaseNumber { get; set; }
        [Display(Name = "Vendor Phone#")]
        public string VendorPhoneNumber { get; set; }
        [Display(Name = "Service Call Date")]
        public DateTime ServiceCallDate { get; set; }
        [Display(Name = "Request Type")]
        public enRequestType RequestType { get; set; }
    }
}
