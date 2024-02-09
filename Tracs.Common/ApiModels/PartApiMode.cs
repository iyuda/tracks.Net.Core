using System;
using System.Collections.Generic;
using System.Text;

namespace Tracs.Common.ApiModels
{
    public class PartApiMode
    {
        public string CaseId { get; set; }
        public string SerialNumber { get; set; }
        public string NewSerialNumber { get; set; }
        public bool IsFullWarranty { get; set; }
        public string Comments { get; set; }

    }
}
