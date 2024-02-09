using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Enumeration;

namespace Tracs.Common.Models
{
    public class TechnicianInfoModel
    {
        public enTechnicianType TechnicianType { get; set; }
        [Display(Name = "Name")]
        public string TechnicianName { get; set; }
        [Display(Name = "Email")]
        public string TechnicianEmail { get; set; }
        [Display(Name = "Phone")]
        public string TechnicianPhone { get; set; }
        [Display(Name = "Company")]
        public string TechnicianCompany { get; set; }
        [Display(Name = "Prime Contractor")]
        public string PrimeContractor { get; set; }
    }
}
