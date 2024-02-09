
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tracs.Common.Models
{
    public class StateModel
    {
        [Display(Name = "StateId")]
        [Required]
        public Int32? StateId { get; set; }

        [Display(Name = "Name")]
        [Required, StringLength(50)]
        public String Name { get; set; }

        [Display(Name = "Abreviation")]
        [Required, StringLength(2)]
        public String Abreviation { get; set; }


        
    }
}
