using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Enumeration;

namespace Tracs.Common.Models
{
    public class WarrantyModel
    {
        [Display(Name = "Warranty")]
        public enWarrantyStatus WarrantyStatus { get; set; }

        [Display(Name = "Shipping Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Shipping Date")]
        public string ShippingDateStr { get; set; }


        [Display(Name = "Manufacture Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime ManufactureDate { get; set; }

        [Display(Name = "Manufacture Date")]
        public string ManufactureDateStr { get; set; }
    }
}
