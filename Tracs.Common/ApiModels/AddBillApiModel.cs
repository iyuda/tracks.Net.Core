using System;
using System.Collections.Generic;
using System.Text;

namespace Tracs.Common.ApiModels
{
    public class AddBillApiModel
    {
        public string CaseId { get; set; }
        public string BillingId { get; set; }
        public string PoOrderNumber { get; set; }
        public string SalesOrderNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public bool ClientRefused { get; set; }
        public List<PartForAddBillApiModel> AddParts { get; set; }
        public List<PartForAddBillApiModel> DeleteParts { get; set; }
    }
}
