using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Enumeration;

namespace Tracs.Common.Models
{
    public class TestInfoModel
    {
        [Display(Name = "Test Date")]
        public DateTime TestDate { get; set; }

        [Display(Name = "Test Date")]
        public string TestDateStr { get; set; }

        [Display(Name = "Test Result")]
        public string TestResultDescription { get; set; }

        public enUnitStatus UnitStatus { get; set; }
    }
}
