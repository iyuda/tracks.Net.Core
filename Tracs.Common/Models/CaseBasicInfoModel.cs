using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tracs.Common.Enumeration;

namespace Tracs.Common.Models
{
    public class CaseBasicInfoModel
    {
        [Display(Name = "Vendor Phone#")]
        public string VendorPhoneNumber { get; set; }
        [Display(Name = "Service Call Date")]
        public DateTime ServiceCallDate { get; set; }
        [Display(Name = "Service Call Date")]
        public string ServiceCallDateStr { get; set; }
        [Display(Name = "Request Type")]
        public enRequestType RequestType { get; set; }
    }
}
