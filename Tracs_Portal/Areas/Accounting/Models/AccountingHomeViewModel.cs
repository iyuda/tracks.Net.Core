using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Models;

namespace TRACSPortal.Areas.Accounting.Models
{
    public class AccountingHomeViewModel
    {
        [Display(Name = "Bank:")]
        public int SelectedBankId { get; set; }
        public string SelectedRadioSearch { get; set; }
        public string SearchKeyWord { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string HomeRouting { get; set; }
        public List<SelectListItem> Banks { get; set; }
        public List<CaseModel> CaseList { get; set; }
        public string SelectedCaseId { get; set; }
    }
}
