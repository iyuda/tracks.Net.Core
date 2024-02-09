using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRACSPortal.Areas.Accounting.Models
{
    public class SearchModel
    {
        public int SelectedBankId { get; set; }
        public string SelectedRadioSearch { get; set; }
        public string SearchKeyWord { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
