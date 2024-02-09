using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Models;

namespace TRACSPortal.Areas.Accounting.Models
{
    public class AccountingPartViewModel
    {
        public string CaseNumber { get; set; }
        public PartModel SelectedPart { get; set; }
        public string Comment { get; set; }
        public string NewSerialNumber { get; set; }
        public string SelectedWarrantyStatus { get; set; }
        public List<SelectListItem> Warranties { get; set; }
        public SearchModel CurrentSearchModel { get; set; }
        public AccountingPartViewModel()
        {
            Warranties = GetWarranties();
        }
        public string ErrorUpdatePart { get; set; }

        private List<SelectListItem> GetWarranties()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var li = new SelectListItem
            {
                Value = "1",
                Text = "Within Warranty"
            };
            list.Add(li);
            var li2 = new SelectListItem
            {
                Value = "2",
                Text = "Out of Warranty"
            };
            list.Add(li2);
            return list;
        }
    }
}
