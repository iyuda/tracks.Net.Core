using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tracs.Common.Models
{
    public class InvoiceInfoModel
    {
        [Display(Name = "Original Invoice Number")]
        public string OriginalInvoiceNumber { get; set; }
    }
}
