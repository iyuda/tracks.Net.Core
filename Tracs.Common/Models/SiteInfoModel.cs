using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracs.Common.Models
{
    public class SiteInfoModel
    {
        [Display(Name = "Branch Name")]
        public string SiteName { get; set; }
        [Display(Name = "Branch Address")]
        public string SiteAddress { get; set; }
        [Display(Name = "Return Address")]
        public string ReturnAddress { get; set; }
    }
}
