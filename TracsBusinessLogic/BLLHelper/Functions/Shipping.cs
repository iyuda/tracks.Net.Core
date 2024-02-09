using System;
using System.Collections.Generic;
using System.Text;
using Tracs.Common.Enumeration;
using Tracs.Common.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Linq;
using StaticHttpContextAccessor.Helpers;
using Microsoft.AspNetCore.Http;




namespace TracsBusinessLogic
{
    public static class Shipping
    {
        public static UserProfileModel GetUserProfile(string UserId)
        {
            UserProfileModel userModel = (UserProfileModel)BLLAppContextExt.Current.Items["UserProfile"];
            if (userModel != null)
            {
                return userModel;
            }
            bool apiError = false;
            try
            {


                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_UserProfile, "GET");

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {

                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        List<UserProfileModel> userProfiles = new List<UserProfileModel>();
                        foreach (JToken item in data)
                        {
                            UserProfileModel userProfile = item.ToObject<UserProfileModel>();
                            userProfile.UserId = UserId;
                            userProfile.Phone = userProfile?.Phone?.Replace(" ", "");
                            try
                            {
                                userProfile.Phone = String.Format("{0:(###)###-####}", Int32.Parse(new String(userProfile.Phone.Where(Char.IsDigit).ToArray())));
                            }
                            catch
                            {
                            }
                            userProfile.IsSubcontractor = userProfile.PrimecontractorId != null;
                            userProfiles.Add(userProfile);
                        }
                        
                        if (userProfiles.Count == 0)
                            userProfiles.Add(new UserProfileModel());
                        BLLAppContextExt.Current.Items["UserProfile"] = userProfiles[0];
                        return userProfiles[0];

                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        apiError = true;
                        throw new WebException(message);
                    }
                }
            }
            catch (WebException ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex);
                return new UserProfileModel { ErrorMsg = JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)) };
            }
            catch (Exception ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex);
                return new UserProfileModel { ErrorMsg = JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)) };
            }

        }
        public static List<ShippingModel> GetShipList(string SearchColumn = null, string SearchValue = null)
        {
            bool apiError = false;
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(ShippingEndpoints.EP_AprrovedCaseId, "GET");

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                objResponseMsg.StatusCode = HttpStatusCode.OK;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {

                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    status = "1";
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        List<ShippingModel> lstShipping = new List<ShippingModel>();
                        foreach (JToken item in data)
                        {
                            ShippingModel shipping = item.ToObject<ShippingModel>();
                            lstShipping.Add(shipping);
                        }
                        return lstShipping;
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        apiError = true;
                        throw new ApplicationException(message);

                    }
                }
            }
            catch (Exception ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex);
                string message = Logger.GetProperErrorMessage(ex.Message, apiError);
                return null;
            }


        }
        public static List<ReceivingModel> GetReceiveList(string SearchColumn = null, string SearchValue = null)
        {
            bool apiError = false;
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(ShippingEndpoints.EP_CaseDetails, "GET");

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                objResponseMsg.StatusCode = HttpStatusCode.OK;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {

                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    status = "1";
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        List<ReceivingModel> lstReceiving = new List<ReceivingModel>();
                        foreach (JToken item in data)
                        {
                            ReceivingModel receiving = item.ToObject<ReceivingModel>();
                            lstReceiving.Add(receiving);
                        }
                        return lstReceiving;
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        apiError = true;
                        throw new ApplicationException(message);

                    }
                }
            }
            catch (Exception ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex);
                string message = Logger.GetProperErrorMessage(ex.Message, apiError);
                return null;
            }


        }
        public static object ReceiveItem(string RmaID)
        {
            bool apiError = false;
            try
            {
                string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                { "CaseId", RmaID},
                                                });


                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(ShippingEndpoints.EP_ReceiveCaseId, "POST", data: postData);
                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    return new { status = status, message = message };
                }
            }
            catch (Exception ex)
            {

                Logger.LogException(ex);
                var status = "0";
                var message = Logger.GetProperErrorMessage(ex.Message, apiError);
                return new { status = status, message = message };
            }
        }
        public static object ShipItem(string RmaID, string TrackingNumber)
        {
            bool apiError = false;
            try
            {
            string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                                            { "CaseId", RmaID},
                                            { "TrackingNumber",TrackingNumber}});


            Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(ShippingEndpoints.EP_TrackingNumber, "POST", data: postData);
                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    return new { status = status, message = message };
                }
            }
            catch (Exception ex)
            {

                Logger.LogException(ex);
                var status = "0";
                var message = Logger.GetProperErrorMessage(ex.Message, apiError);
                return new { status = status, message = message };
            }

        }

        }
        #region Private Functions

        #endregion

}
