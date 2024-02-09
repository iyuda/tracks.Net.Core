using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracs.Common.Models
{
    public class CountryModel
    {
        [Display(Name = "CountryId")]
        [Required]
        public Int32? CountryId { get; set; }

        [Display(Name = "Name")]
        [Required, StringLength(50)]
        public String Name { get; set; }

        public static List<CountryModel> fullList { get; set; }
        public List<StateModel> stateList { get; set; }
        
    }
}

