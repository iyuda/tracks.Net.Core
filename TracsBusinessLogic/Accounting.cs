using System;
using System.Collections.Generic;
using System.Text;
using Tracs.Common;
using Tracs.Common.Enumeration;
using Tracs.Common.Models;
using Tracs.Common.ApiModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace TracsBusinessLogic
{
   public static class Accountings
    {
        #region Public Funcitons
        public static List<BankModel> GetBankList()
        {
            List<BankModel> banks = new List<BankModel>();
            banks = GetBanks("0");
            return banks;
        }
        public static List<CaseModel> GetCasesByKeyword(string caseId)
        {
            List<CaseModel> cases = new List<CaseModel>();
            try
            {
                cases = GetCases("Case/CaseId/Keyword", new List<string> { caseId });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return cases;
        }
        public static List<CaseModel> GetCasesByBankId(int bankId)
        {
            List<CaseModel> cases = new List<CaseModel>();
            try
            {
                cases = GetCases("Case/CaseId/Company", new List<string> { bankId.ToString()});
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return cases;
        }
        public static List<CaseModel> GetCasesByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            List<CaseModel> cases = new List<CaseModel>();
            try
            {
                cases = GetCases("Case/CaseId/Date", new List<string> { dateFrom.ToShortDateString().Replace("/","-"), dateTo.ToShortDateString().Replace("/", "-") });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return cases;
        }
        public static CaseModel GetCaseByCaseId(string caseId)
        {
            CaseModel caseModel = new CaseModel();
            try
            {
                caseModel = GetCaseDetails("Case/CaseDetails", new List<string> { caseId });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return caseModel;
        }
        public static BillingInfoModel GetBillingDetailsById(string billingId)
        {
            BillingInfoModel billing = new BillingInfoModel();
            try
            {
                billing = GetBillingDetailsByBillingId("Case/BillingDetails", new List<string> { billingId });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return billing;
        }
        public static PartModel GetPartDetailsByIds(string caseNumber, string serialNumber)
        {
            PartModel partModel = new PartModel();
            try
            {
                partModel = GetPartDetails("Case/PartDetails", new List<string> { serialNumber, caseNumber });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return partModel;
        }
        public static ResponseResult SavePart(PartModel partModel)
        {
            ResponseResult result = new ResponseResult();
            PartApiMode partApiMode = new PartApiMode();
            partApiMode.CaseId = partModel.CaseId;
            partApiMode.SerialNumber = partModel.SerialNumber;
            partApiMode.NewSerialNumber = partModel.ReplacementSerialNumber;
            partApiMode.IsFullWarranty = partModel.IsFullWarranty;
            partApiMode.Comments = partModel.Observations;
            try
            {
                string postData = JsonConvert.SerializeObject(partApiMode);

                result = ApiHelper.ApiPost("Case/UpdatePartDetails", postData);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                result.ResultMessage = "Save part info failed, please try later.";
            }
            return result;
        }
        public static ResponseResult SaveBilling(AddBillApiModel addBillApiModel)
        {
            ResponseResult result = new ResponseResult();
          
            try
            {
                string postData = JsonConvert.SerializeObject(addBillApiModel);

                result = ApiHelper.ApiPost("Case/ManageBill", postData);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                result.ResultMessage = "Save part info failed, please try later.";
            }
            return result;
        }
        public static ResponseResult AddRMANumberToCase(AddRMANumberApiModel addRMANumberApiModel)
        {
            ResponseResult result = new ResponseResult();

            try
            {
                string postData = JsonConvert.SerializeObject(addRMANumberApiModel);

                result = ApiHelper.ApiPost("Case/AddRMANumber", postData);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                result.ResultMessage = "Save RMANumber info failed, please try later.";
            }
            return result;
        }
        public static ResponseResult DeleteBilling(string billingId)
        {
            ResponseResult result = new ResponseResult();
            DeleteBillApiModel deleteBillApiModel = new DeleteBillApiModel();
            deleteBillApiModel.BillingId = Convert.ToInt32(billingId);
            try
            {
                string postData = JsonConvert.SerializeObject(deleteBillApiModel);
                result = ApiHelper.ApiPost("Case/BillingDetails/DeleteBilling", postData);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                result.ResultMessage = "Save part info failed, please try later.";
            }
            return result;
        }
        public static void LogError(string errorMessage)
        {
            Logger.LogError(errorMessage, "ErrorLog_Accounting", "Accounting");
        }
        #endregion
        #region Private Funcitons
        private static List<BankModel> GetBanks(string FirmId)
        {
            //bool apiError = false;
            List<BankModel> banks = new List<BankModel>();
            try
            {
                //WebHeaderCollection _token = new WebHeaderCollection() { { "Token", Token } };
                //var userInfo = ClientDetection.GetUserEnvironment(Request);
                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest("Company/CompanyName", "GET", parameters: new List<string> { FirmId });

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    throw new ApplicationException(message);
                }
                else
                {
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        
                        foreach (JToken item in data)
                        {
                            BankModel bank = item.ToObject<BankModel>();
                            bank.BankID = int.Parse(item["CompanyId"].ToString());
                            bank.BankName = item["Name"].ToString();
                            banks.Add(bank);
                        }
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        //ModelState.AddModelError("", message);

                        throw new Exception(message);
                    }
                }
            }
            catch (Exception ex)
            {
                //Session["RmaErrors"] = Logger.GetProperErrorMessage(ex.Message, apiError);
                Logger.LogException(ex);
            }
            return banks;
        }
        private static List<CaseModel> GetCases(string action, List<string> parameters)
        {
            List<CaseModel> cases = new List<CaseModel>();

            ////*******This is debug code******//
            //CaseModel caseModelx = new CaseModel();
            //caseModelx.CaseNumber = "PBT764";
            //caseModelx.ClientType = enTechnicianType.ParabitTech.ToString();
            //caseModelx.ReceivedDate = DateTime.Now;
            //caseModelx.CaseStatus = enCaseStatus.Open;
            //cases.Add(caseModelx);
            ////*******This is debug code******//

            JArray dataJson = ApiHelper.ExtractJsonData(action, parameters);
            foreach (JToken item in dataJson)
            {
                CaseModel caseModel = new CaseModel();// item.ToObject<CaseModel>();
                caseModel.CaseNumber = item["RMAId"].ToString();
                caseModel.ReceivedDateStr = item["ReceivedDate"].Type == JTokenType.Null ? "N/A" : DateTime.Parse(item["ReceivedDate"].ToString()).ToShortDateString();
                caseModel.ClientType = item["RMAId"] == null ? "N/A" : item["RMAId"].ToString().StartsWith("PB") == true ? enTechnicianType.ParabitTech.ToString() : enTechnicianType.OutsideCustomer.ToString();
                caseModel.CaseStatusStr = item["CurrentStatus"] == null ? "N/A" : item["CurrentStatus"].ToString();
                cases.Add(caseModel);
            }
            return cases;
        }
        private static CaseModel GetCaseDetails(string action, List<string> parameters)
        {
            CaseModel caseModel = new CaseModel();
            JArray dataJson = ApiHelper.ExtractJsonData(action, parameters);
            List<PartForCaseModel> listPartForCase = new List<PartForCaseModel>();
            List<PartForCaseModel> listPartForAddBilling = new List<PartForCaseModel>();
            List<BillingInfoModel> listBilling = new List<BillingInfoModel>();
            try
            {
                foreach (JToken item in dataJson)
                {
                    caseModel.CaseNumber = item["RMAId"].ToString();
                    caseModel.RMANumber = item["RMANumber"] == null ? "N/A" : item["RMANumber"].ToString();
                    caseModel.ReceivedDateStr = item["DateReceivedRMA"].Type == JTokenType.Null ? "N/A" : DateTime.Parse(item["DateReceivedRMA"].ToString()).ToShortDateString();
                    caseModel.ClientType = item["RMAId"] == null ? "N/A" : item["RMAId"].ToString().StartsWith("PB") == true ? enTechnicianType.ParabitTech.ToString() : enTechnicianType.OutsideCustomer.ToString();
                    caseModel.SystemType = item["RMAId"] == null ? "N/A" : item["RMAId"].ToString().StartsWith("PB") == true ? enSystemType.ESC.ToString() : enSystemType.FishBowl.ToString();
                    caseModel.CaseStatusStr = item["CurrentStatus"] == null ? "N/A" : item["CurrentStatus"].ToString();


                    CaseBasicInfoModel caseBasicInfo = new CaseBasicInfoModel();
                    caseBasicInfo.VendorPhoneNumber = item["TrackingNumber"] == null ? "N/A" : item["TrackingNumber"].ToString();
                    caseBasicInfo.ServiceCallDateStr = item["ServiceCallDate"].Type == JTokenType.Null ? "N/A" : DateTime.Parse(item["ServiceCallDate"].ToString()).ToShortDateString();
                    caseBasicInfo.RequestType = enRequestType.Service;
                    caseModel.CaseBasicInfo = caseBasicInfo;

                    TechnicianInfoModel technicianInfo = new TechnicianInfoModel();
                    technicianInfo.TechnicianName = item["UserName"] == null ? "N/A" : item["UserName"].ToString();// "Emily Zhang";
                    technicianInfo.TechnicianEmail = item["Email"] == null ? "N/A" : item["Email"].ToString();
                    technicianInfo.TechnicianPhone = item["UserPhoneNumber"] == null ? "N/A" : item["UserPhoneNumber"].ToString();
                    technicianInfo.TechnicianCompany = item["TechFirm"] == null ? "N/A" : item["TechFirm"].ToString();
                    //technicianInfo.PrimeContractor = item["TechName"] == null ? "N/A" : item["TechName"].ToString(); ;
                    caseModel.TechnicianInfo = technicianInfo;

                    SiteInfoModel siteInfo = new SiteInfoModel();
                    siteInfo.ReturnAddress = item["ReturnAddress"] == null ? "N/A" : item["ReturnAddress"].ToString();
                    siteInfo.SiteName = item["BankName"] == null ? "N/A" : item["BankName"].ToString();
                    siteInfo.SiteAddress = item["SiteFullAddress"] == null ? "N/A" : item["SiteFullAddress"].ToString();
                    caseModel.SiteInfo = siteInfo;
                    
                    //PartForCaseModel partModel = item.ToObject<PartForCaseModel>();
                    foreach (JToken part in item["Parts"])
                    {
                        PartForCaseModel partModel = new PartForCaseModel();
                        partModel.PartNumber = part["PartNumber"] == null ? "N/A" : part["PartNumber"].ToString();
                        partModel.PartDescription = part["PartDescription"] == null ? "N/A" : part["PartDescription"].ToString();
                        partModel.SerialNumber = part["SerialNumber"] == null ? "N/A" : part["SerialNumber"].ToString();
                        partModel.WarrantyStatus = part["WarrantyStatus"] == null ? "N/A" : part["WarrantyStatus"].ToString();
                        partModel.BillingId = part["BillingId"] == null ? "N/A" : part["BillingId"].ToString();
                        listPartForCase.Add(partModel);

                        partModel.PartDescription = partModel.PartDescription.Split(" ")[0];

                        if (part["BillingId"] == null || partModel.BillingId == "")
                        {
                            partModel.IsSignToBilling = false;
                            partModel.IsSignToBillingPre = false;
                            listPartForAddBilling.Add(partModel);
                        }
                        else
                        {
                            partModel.IsSignToBilling = true;
                            partModel.IsSignToBillingPre = true;
                        }
                    }

                    ////*******This is debug code******//
                    //List<PartForCaseModel> listPart = new List<PartForCaseModel>();
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    PartForCaseModel part = new PartForCaseModel();
                    //    part.PartNumber = "200-10988-BT" + i;
                    //    part.PartDescription = "MMR BT Reader" + i;
                    //    part.PartFamily = "Part Family" + i;
                    //    part.TestResultDescription = "IsPhysicalDamage";
                    //    part.SerialNumber = "123456" + i;
                    //    part.WarrantyStatus = enWarrantyStatus.Outof.ToString();
                    //    //part.IsSignToBilling = true;
                    //    listPartForCase.Add(part);
                    //    listPartForAddBilling.Add(part);
                    //}
                    ////*******This is debug code******//


                    //BillingInfoModel billingInfoModel = item.ToObject<BillingInfoModel>();
                    foreach (JToken part in item["Billing"])
                    {
                        BillingInfoModel billingInfoModel = new BillingInfoModel();
                        billingInfoModel.PoOrderNumber = part["PoOrderNumber"] == null ? "N/A" : part["PoOrderNumber"].ToString();
                        billingInfoModel.SalesOrderNumber = part["SalesOrderNumber"] == null ? "N/A" : part["SalesOrderNumber"].ToString();
                        billingInfoModel.InvoiceNumber = part["InvoiceNumber"] == null ? "N/A" : part["InvoiceNumber"].ToString();
                        billingInfoModel.ClientRefused = part["ClientRefused"] == null ? false : Convert.ToBoolean(part["ClientRefused"]);
                        billingInfoModel.BillingId = part["BillingId"] == null ? "N/A" : part["BillingId"].ToString();
                        listBilling.Add(billingInfoModel);
                    }
                }
                caseModel.PartListForCase = listPartForCase;
                caseModel.PartListForAddBilling = listPartForAddBilling;
                caseModel.BillingListForCase = listBilling;
            }
            catch (Exception ex)
            {
                //log ex
                Logger.LogException(ex);
            }
            return caseModel;
        }
        private static BillingInfoModel GetBillingDetailsByBillingId(string action, List<string> parameters)
        {
            BillingInfoModel billingInfoModel = new BillingInfoModel();
            JArray dataJson = ApiHelper.ExtractJsonData(action, parameters);
            List<PartForCaseModel> listPart = new List<PartForCaseModel>();
            List<PartForAddBillApiModel> listPartForAddBillApiModel = new List<PartForAddBillApiModel>();
            try
            {
                foreach (JToken item in dataJson)
                {
                    billingInfoModel.BillingId = item["BillingId"].ToString();
                    billingInfoModel.PoOrderNumber = item["PONumber"] == null ? "N/A" : item["PONumber"].ToString();
                    billingInfoModel.SalesOrderNumber = item["SONumber"] == null ? "N/A" : item["SONumber"].ToString();
                    billingInfoModel.InvoiceNumber = item["InvoiceNumber"] == null ? "N/A" : item["InvoiceNumber"].ToString();
                    billingInfoModel.RMANumber = item["RMAId"] == null ? "N/A" : item["RMAId"].ToString();
                    billingInfoModel.ClientRefused = item["ClientRefused"] == null ? false : Convert.ToBoolean(item["ClientRefused"]);

                    //PartForCaseModel partModel = item.ToObject<PartForCaseModel>();
                    foreach (JToken part in item["Parts"])
                    {
                        PartForCaseModel partForCaseModel = new PartForCaseModel();
                        PartForAddBillApiModel partForAddBillApiModel = new PartForAddBillApiModel();
                        partForCaseModel.PartNumber = part["PartNumber"] == null ? "N/A" : part["PartNumber"].ToString();
                        partForCaseModel.PartDescription = part["PartDescription"] == null ? "N/A" : part["PartDescription"].ToString();
                        partForCaseModel.SerialNumber = part["SerialNumber"] == null ? "N/A" : part["SerialNumber"].ToString();
                        partForCaseModel.WarrantyStatus = part["IsFullWarranty"] == null ? "N/A" : part["IsFullWarranty"].ToString();
                        partForCaseModel.IsSignToBilling = true;
                        partForCaseModel.IsSignToBillingPre = true;

                        partForCaseModel.PartDescription = partForCaseModel.PartDescription.Split(" ")[0];

                        partForAddBillApiModel.PartNumber = partForCaseModel.PartNumber;
                        partForAddBillApiModel.SerialNumber = partForCaseModel.SerialNumber;

                        listPart.Add(partForCaseModel);
                        listPartForAddBillApiModel.Add(partForAddBillApiModel);
                    }
                }
                billingInfoModel.PartListForBilling = listPart;
                //billingInfoModel.PartListForBillingOld = listPartForAddBillApiModel;
            }
            catch (Exception ex)
            {
                //log ex
                Logger.LogException(ex);
            }

            return billingInfoModel;
        }
        private static PartModel GetPartDetails(string action, List<string> parameters)
        {
            PartModel partModel = new PartModel();
            JArray dataJson = ApiHelper.ExtractJsonData(action, parameters);
            try
            {
                foreach (JToken part in dataJson)
                {
                    partModel.PartId = part["PartId"] == null ? "N/A" : part["PartId"].ToString();
                    partModel.PartNumber = part["PartNumber"] == null ? "N/A" : part["PartNumber"].ToString();
                    partModel.PartFamily = part["PartFamily"] == null ? "N/A" : part["PartFamily"].ToString();
                    partModel.PartDescription = part["PartDescription"] == null ? "N/A" : part["PartDescription"].ToString();
                    partModel.PartDescription = partModel.PartDescription.Split(" ")[0];
                    partModel.SerialNumber = part["SerialNumber"] == null ? "N/A" : part["SerialNumber"].ToString();
                    partModel.ReplacementSerialNumber = part["ReplacementSerialNumber"] == null ? "N/A" : part["ReplacementSerialNumber"].ToString();
                    partModel.Observations = part["Observations"] == null ? "N/A" : part["Observations"].ToString();
                    partModel.PartResult = part["TestResultDescription"] == null ? "N/A" : part["TestResultDescription"].ToString();
                   
                    WarrantyModel warranty = new WarrantyModel();
                    warranty.ShippingDateStr = part["DateShipped"].Type == JTokenType.Null ? "N/A" : DateTime.Parse(part["DateShipped"].ToString()).ToShortDateString();
                    warranty.ManufactureDateStr = part["DateManufactured"].Type == JTokenType.Null ? "N/A" : DateTime.Parse(part["DateManufactured"].ToString()).ToShortDateString();
                    warranty.WarrantyStatus = part["IsFullWarranty"].Type == JTokenType.Null ? enWarrantyStatus.Outof : Convert.ToBoolean(part["IsFullWarranty"]) == true ? enWarrantyStatus.Within : enWarrantyStatus.Outof;
                    partModel.WarrantyInfo = warranty;

                    InvoiceInfoModel invoice = new InvoiceInfoModel();
                    invoice.OriginalInvoiceNumber = part["InvoiceNumber"] == null ? "N/A" : part["InvoiceNumber"].ToString();
                    partModel.InvoiceInfo = invoice;

                    TestInfoModel testInfo = new TestInfoModel();
                    testInfo.TestDateStr = part["TestedDate"].Type == JTokenType.Null ? "N/A" : DateTime.Parse(part["TestedDate"].ToString()).ToShortDateString();
                    testInfo.TestResultDescription = part["TestResultDescription"] == null ? "N/A" : part["TestResultDescription"].ToString();
                    partModel.TestInfo = testInfo;
                }
            }
            catch(Exception ex)
            {
                //log ex
                Logger.LogException(ex);
            }
            return partModel;
        }
        #endregion

        //private static JArray ExtractJsonData(string action, string Token, List<string> parameters)
        //{
        //    List<CaseModel> cases = new List<CaseModel>();
        //    JArray dataJson = null;
        //    try
        //    {
        //        WebHeaderCollection _token = new WebHeaderCollection() { { "Token", Token } };
        //        //var userInfo = ClientDetection.GetUserEnvironment(Request);
        //        //Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(userinfo, action, "GET", parameters: parameters, WebHeaders: _token);
        //        Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(action, "GET", parameters: parameters, WebHeaders: _token);

        //        HttpResponseMessage objResponseMsg = response.Item1;
        //        string strResponseMsg = response.Item2;

        //        if (objResponseMsg.StatusCode != HttpStatusCode.OK)
        //        {
        //            var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
        //            //apiError = true;
        //            throw new ApplicationException(message);
        //        }
        //        else
        //        {
        //            var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
        //            if (status.ToString() == "1")
        //            {
        //                dataJson = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
        //            }
        //            else
        //            {
        //                var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();

        //                throw new Exception(message);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }
        //    return dataJson;
        //}
        //public static List<PartModel> GetPartsByCaseId(string caseId)
        //{
        //    List<PartModel> listPart = new List<PartModel>();
        //    try
        //    {
        //        listPart = GetPartList(caseId);
        //    }
        //    catch (Exception ex)
        //    {
        //        //logging
        //    }

        //    return listPart;
        //}
        //public static List<BillingInfoModel> GetBillingsByCaseId(string caseId)
        //{
        //    List<BillingInfoModel> listBilling = new List<BillingInfoModel>();
        //    try
        //    {
        //        listBilling = GetBillingList(caseId);
        //    }
        //    catch (Exception ex)
        //    {
        //        //logging
        //    }

        //    return listBilling;
        //}
        //private static List<PartModel> GetPartList(string caseId)
        //{
        //    List<PartModel> listPart = new List<PartModel>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        PartModel part = new PartModel();
        //        part.PartNumber = "200-10988-BT" + i;
        //        part.PartDescription = "MMR BT Reader" + i;
        //        part.PartFamily = "Part Family" + i;
        //        part.PartResult = "IsPhysicalDamage";
        //        part.SerialNumber = "123456" + i;

        //        WarrantyModel warranty = new WarrantyModel();
        //        warranty.WarrantyStatus = enWarrantyStatus.Outof;
        //        part.WarrantyInfo = warranty;

        //        listPart.Add(part);
        //    }

        //    return listPart;
        //}
        //private static List<BillingInfoModel> GetBillingList(string caseId)
        //{
        //    List<BillingInfoModel> listBilling = new List<BillingInfoModel>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        BillingInfoModel billing = new BillingInfoModel();
        //        billing.InvoiceNumber = "INC00999" + i;
        //        billing.PoOrderNumber = "PO9999" + i;
        //        billing.ClientRefused = false;
        //        billing.SalesOrderNumber = "123456" + i;
        //        billing.BillingStatus = enBillingStatus.ReceivedPO.ToString();
        //        listBilling.Add(billing);
        //    }
        //    return listBilling;
        //}
        //private static List<PartForCaseModel> GetPartsByInvoiceId(string invoiceId)
        //{
        //    List<PartForCaseModel> listPart = new List<PartForCaseModel>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        PartForCaseModel part = new PartForCaseModel();
        //        part.PartNumber = "200-10988-BT" + i;
        //        part.PartDescription = "MMR BT Reader" + i;
        //        part.PartFamily = "Part Family" + i;
        //        part.TestResultDescription = "IsPhysicalDamage";
        //        part.SerialNumber = "123456" + i;
        //        part.WarrantyStatus = enWarrantyStatus.Outof.ToString();
        //        part.IsSignToBilling = true;
        //        listPart.Add(part);
        //    }

        //    return listPart;
        //}
        //private static PartModel GetPartDetailsBySerialNumber(string serialNumber)
        //{
        //    PartModel part = new PartModel();
        //    part.PartNumber = "200-10988-BT";
        //    part.PartDescription = "MMR BT Reader";
        //    part.PartFamily = "Part Family";
        //    part.PartResult = "IsPhysicalDamage";
        //    part.SerialNumber = serialNumber;

        //    WarrantyModel warranty = new WarrantyModel();
        //    warranty.WarrantyStatus = enWarrantyStatus.Outof;
        //    warranty.ShippingDate = DateTime.Now;
        //    warranty.ManufactureDate = DateTime.Now;
        //    part.WarrantyInfo = warranty;

        //    InvoiceInfoModel invoice = new InvoiceInfoModel();
        //    invoice.OriginalInvoiceNumber = "INV20000";
        //    part.InvoiceInfo = invoice;

        //    return part;
        //}

        //private static List<CaseModel> GetCaseListx(string caseId)
        //{
        //    List<CaseModel> listCase = new List<CaseModel>();
        //    //CaseModel caseModel = new CaseModel();
        //    //caseModel.CaseNumber = "PEST12345";
        //    //caseModel.ClientType = enTechnicianType.ParabitTech.ToString();
        //    //listCase.Add(caseModel);
        //    //CaseModel caseModel1 = new CaseModel();
        //    //caseModel1.CaseNumber = "PEST0008";
        //    //caseModel1.ClientType = enTechnicianType.OutsideCustomer.ToString();
        //    //listCase.Add(caseModel1);

        //    for (int i = 0; i < 5; i++)
        //    {
        //        CaseModel caseModel = new CaseModel();
        //        caseModel.CaseNumber = "PEST0000" + i;
        //        caseModel.ClientType = enTechnicianType.ParabitTech.ToString();
        //        caseModel.ReceivedDate = DateTime.Now;
        //        caseModel.CaseStatus = enCaseStatus.Open;
        //        listCase.Add(caseModel);
        //    }
        //    return listCase;
        //}
        //private static List<BankModel> GetBankListx()
        //{
        //    List<BankModel> banks = new List<BankModel>();

        //    var bank1 = new BankModel
        //    {
        //        BankID = 1,
        //        BankName = "Chase"
        //    };
        //    banks.Add(bank1);
        //    var bank2 = new BankModel
        //    {
        //        BankID = 2,
        //        BankName = "Bank2"
        //    };
        //    banks.Add(bank2);
        //    var bank3 = new BankModel
        //    {
        //        BankID = 3,
        //        BankName = "Band3"
        //    };
        //    banks.Add(bank3);

        //    return banks;
        //}
        //private static CaseModel GetCaseById(string id)
        //{
        //    CaseModel caseModel = new CaseModel();
        //    caseModel.CaseNumber = id;
        //    caseModel.RMANumber = "123wrtgjgf";

        //    CaseBasicInfoModel caseBasicInfo = new CaseBasicInfoModel();
        //    caseBasicInfo.VendorPhoneNumber = "123456";
        //    caseBasicInfo.ServiceCallDate = DateTime.Now; ;
        //    caseBasicInfo.RequestType = enRequestType.Service;
        //    caseModel.CaseBasicInfo = caseBasicInfo;

        //    TechnicianInfoModel technicianInfo = new TechnicianInfoModel();
        //    technicianInfo.TechnicianName = "Emily Zhang";
        //    technicianInfo.TechnicianEmail = "test@parabit.com";
        //    technicianInfo.TechnicianPhone = "123-456-7890";
        //    technicianInfo.TechnicianCompany = "SE Security System";
        //    technicianInfo.PrimeContractor = "JMG Security System";
        //    caseModel.TechnicianInfo = technicianInfo;

        //    SiteInfoModel siteInfo = new SiteInfoModel();
        //    siteInfo.ReturnAddress = "500 old country Rd., Farmingdale, NY 11735";
        //    siteInfo.SiteName = "Bank of America";
        //    siteInfo.SiteAddress = "500 old country Rd., Farmingdale, NY 11735";
        //    caseModel.SiteInfo = siteInfo;

        //    caseModel.PartListForCase = GetPartsByCaseId(id);
        //    caseModel.BillingListForCase = GetBillingsByCaseId(id);

        //    return caseModel;
        //}

        //private static CaseModel GetCaseDetailsx(string action, string Token, List<string> parameters)
        //{
        //    CaseModel caseModel = new CaseModel();
        //    JArray dataJson = ExtractJsonData(action, Token, parameters);
        //    List<PartModel> listPart = new List<PartModel>();
        //    List<BillingInfoModel> listBilling = new List<BillingInfoModel>();
        //    foreach (JToken item in dataJson)
        //    {

        //        CaseBasicInfoModel caseBasicInfo = new CaseBasicInfoModel();
        //        caseBasicInfo.VendorPhoneNumber = "123456";
        //        caseBasicInfo.ServiceCallDate = DateTime.Now; ;
        //        caseBasicInfo.RequestType = enRequestType.Service;
        //        caseModel.CaseBasicInfo = caseBasicInfo;

        //        TechnicianInfoModel technicianInfo = new TechnicianInfoModel();
        //        technicianInfo.TechnicianName = item["TechName"] == null ? "N/A" : item["TechName"].ToString();// "Emily Zhang";
        //        technicianInfo.TechnicianEmail = item["TechEmail"] == null ? "N/A" : item["TechEmail"].ToString();
        //        technicianInfo.TechnicianPhone = item["TechPhone"] == null ? "N/A" : item["TechPhone"].ToString();
        //        technicianInfo.TechnicianCompany = item["TechFirm"] == null ? "N/A" : item["TechFirm"].ToString();
        //        //technicianInfo.PrimeContractor = item["TechName"] == null ? "N/A" : item["TechName"].ToString(); ;
        //        caseModel.TechnicianInfo = technicianInfo;

        //        SiteInfoModel siteInfo = new SiteInfoModel();
        //        siteInfo.ReturnAddress = "500 old country Rd., Farmingdale, NY 11735";
        //        siteInfo.SiteName = "Bank of America";
        //        siteInfo.SiteAddress = "500 old country Rd., Farmingdale, NY 11735";
        //        caseModel.SiteInfo = siteInfo;

        //        PartModel partModel = item.ToObject<PartModel>();
        //        listPart.Add(partModel);
        //        BillingInfoModel billingInfoModel = new BillingInfoModel();// item.ToObject<BillingInfoModel>();

        //        billingInfoModel.PoOrderNumber = "PO100000";
        //        billingInfoModel.InvoiceNumber = "INV20000";
        //        billingInfoModel.SalesOrderNumber = "ODR30000";
        //        listBilling.Add(billingInfoModel);



        //        PartModel part = new PartModel();
        //        part.PartNumber = "200-10988-BT";
        //        part.PartDescription = "MMR BT Reader";
        //        part.PartFamily = "Part Family";
        //        part.PartResult = "IsPhysicalDamage";
        //        part.SerialNumber = "123456";

        //        WarrantyModel warranty = new WarrantyModel();
        //        warranty.WarrantyStatus = enWarrantyStatus.Outof;
        //        part.WarrantyInfo = warranty;

        //        listPart.Add(part);

        //    }
        //    caseModel.CaseNumber = dataJson[0]["CaseId"].ToString();
        //    caseModel.RMANumber = dataJson[0]["CaseId"].ToString();
        //    caseModel.PartListForCase = listPart;
        //    caseModel.BillingListForCase = listBilling;
        //    //caseModel.CaseBasicInfo.

        //    return caseModel;
        //}
    }
}
