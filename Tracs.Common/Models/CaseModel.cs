using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Enumeration;

namespace Tracs.Common.Models
{
    public class CaseModel
    {
        public string CaseNumber { get; set; }

        [Display(Name = "RMA Number")]
        public string RMANumber { get; set; }

        [Display(Name = "RMA Number")]
        public string NewRMANumber { get; set; }

        [Display(Name = "ESCDispatch Number")]
        public string ESCDispatchNumber { get; set; }

        [Display(Name = "Received Date")]
        [DisplayFormat(DataFormatString ="{0:MM-dd-yyyy}")]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Received Date")]
        public string ReceivedDateStr { get; set; }


        [Display(Name = "Client Type")]
        public string ClientType { get; set; }
        [Display(Name = "System Type")]
        public string SystemType { get; set; }

        [Display(Name = "Case Status")]
        public enCaseStatus CaseStatus { get; set; }
        [Display(Name = "Case Status")]
        public string CaseStatusStr { get; set; }

        public CaseBasicInfoModel CaseBasicInfo { get; set; }
        public TechnicianInfoModel TechnicianInfo { get; set; }
        public SiteInfoModel SiteInfo { get; set; }
        public TestInfoModel TestInfo { get; set; }

        public List<PartForCaseModel> PartListForCase { get; set; }
        public List<BillingInfoModel> BillingListForCase { get; set; }
        public List<PartForCaseModel> PartListForAddBilling { get; set; }
    }
}
