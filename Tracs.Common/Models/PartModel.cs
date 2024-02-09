using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracs.Common.Models
{
    public class PartModel
    {
        public string CaseId { get; set; }
        public string PartId { get; set; }

        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "New SerialNumber")]
        [Required]
        [RegularExpression("^[a-z]*$", ErrorMessage = "only alphabet")]
        public string ReplacementSerialNumber { get; set; }

        [Display(Name = "Part Description")]
        public string PartDescription { get; set; }

        [Display(Name = "PartFamily")]
        public string PartFamily { get; set; }

        [Display(Name = "Test Result")]
        public string PartResult { get; set; }

        [Display(Name = "Complain Confirmed")]
        public bool IsConfirmed { get; set; }

        [Display(Name = "Comment")]
        public string Observations { get; set; }

        public bool IsFullWarranty { get; set; }

        [Display(Name = "Reworked Date")]
        public DateTime DateReworked { get; set; }

        [Display(Name = "Reworked Date")]
        public string DateReworkedStr { get; set; }

        [Display(Name = "Installed Date")]
        public DateTime DateInstalled { get; set; }

        [Display(Name = "Installed Date")]
        public string DateInstalledStr { get; set; }

        [Display(Name = "Completed Date")]
        public DateTime DateCompleted { get; set; }

        [Display(Name = "Completed Date")]
        public string DateCompletedStr { get; set; }

        public TestInfoModel TestInfo { get; set; }
        public WarrantyModel WarrantyInfo { get; set; }
        public BillingInfoModel BillingInfo { get; set; }
        public InvoiceInfoModel InvoiceInfo { get; set; }
    }
}
