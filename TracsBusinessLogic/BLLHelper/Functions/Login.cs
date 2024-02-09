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
    public static class Login
    {
        public static string PasswordResetUpdate(string UserId, string Password)
        {
            bool apiError = false;
            try
            {
                string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                    { "UserId", UserId},
                                                    { "NewPassword", Password }});

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_ResetPassword, "POST", data: postData);


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
                    return strResponseMsg;

                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return JsonConvert.SerializeObject(new { status = 0, message = Logger.GetProperErrorMessage(ex.Message, apiError)});
            }
        }
        public static string VerifyCodeUpdate(string UserId, string VerificationCode)
        {
            bool apiError = false;
            try
            {
                string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                    { "UserId", UserId},
                                                    { "VerificationCode", VerificationCode }});

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_VerifyCode, "POST", data: postData);


                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    if (String.IsNullOrEmpty(message))
                        message = "There was an error processing your request";
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    return strResponseMsg;

                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return JsonConvert.SerializeObject(new { status = 0, message = Logger.GetProperErrorMessage(ex.Message, apiError) });
            }
        }
        public static string ResendCode(string UserId)
        {
            string postData = JsonConvert.SerializeObject(new Dictionary<string, string> { { "UserId", UserId } });

            Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_ResendCode, "GET", parameters: new List<string> { UserId });


            HttpResponseMessage objResponseMsg = response.Item1;
            string strResponseMsg = response.Item2;
            if (objResponseMsg.StatusCode != HttpStatusCode.OK)
            {
                var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                if (String.IsNullOrEmpty(message))
                    message = "There was an error processing your request";
                return JsonConvert.SerializeObject(new { status = 0, message = message });
            }
            else
            {

                return strResponseMsg;
            }
        }
        public static string ValidateEmailUpdate(string Email)
        {
            bool apiError = false;
            try
            {
                string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                    { "Email", Email}});

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_ValidateEmail, "POST", data: postData);


                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    if (String.IsNullOrEmpty(message))
                        message = "There was an error processing your request";
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    return strResponseMsg;

                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return JsonConvert.SerializeObject(new { status = 0, message = Logger.GetProperErrorMessage(ex.Message, apiError) });
            }
        }
        public static string UserRegistrationUpdate(UserRegistrationModel model)
        {
            bool apiError = false;
            try
            {
                string postData = JsonConvert.SerializeObject(model);
                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_Registration, "POST", data: postData);


                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;
                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();  //var message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    if (String.IsNullOrEmpty(message))
                        message = "There was an error processing your request";
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    return strResponseMsg;

                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return JsonConvert.SerializeObject(new { status = 0, message = Logger.GetProperErrorMessage(ex.Message, apiError) });
            }
        }
        public static dynamic ValidateLogin(LoginModel model)
        {

            string postData = JsonConvert.SerializeObject(model);

            Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_ValidateLogin, "POST", data: postData);

            HttpResponseMessage objResponseMsg = response.Item1;
            string strResponseMsg = (string)response.Item2;
            if (objResponseMsg.StatusCode != HttpStatusCode.OK)
            {
                string message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                if (message == "") message = strResponseMsg;
                return message;

            }
            else
            {
                try
                {
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        JToken profileToken = data?[0];
                        UserModel user = profileToken?.ToObject<UserModel>();
                        user.id = int.Parse(profileToken?["UserId"].ToString());
                        string passwordTypeId = profileToken?["PasswordTypeId"]?.ToString();
                        string token = profileToken?["token"]?.ToString();
                        BLLAppContextExt.Current.Session.SetString("Token", token);

                        return user;

                    }
                    else
                    {
                        string message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        return message;

                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                    return ("There was an error processing your request.  Please try again later.");

                }
            }


        }
        
        public static JObject SubmitReturnAddress(ReturnAddressModel model)
        {
            try
            {
                var response = CommonFunctions.PostAddress<ReturnAddressModel>(model, RmaEndpoints.EP_AddReturnAddress);
                return JObject.FromObject(new
                {
                    status = ((JToken)response?["status"])?.ToString(),
                    message = Logger.GetProperErrorMessage(((JToken)response?["message"])?.ToString(), true),

                    data = new
                    {
                        CompanyId = ((JToken)response?["data"]?[0]["CompanyId"])?.ToString(),
                        SiteId = ((JToken)response?["data"]?[0]["SiteId"])?.ToString()
                    },

                });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                var strError = (new JObject(new JProperty("status", 0), new JProperty("message", "There was an error processing your request.  Please try again later."))).ToString();
                return JObject.FromObject(new
                {
                    status = "0",
                    message = Logger.GetProperErrorMessage(strError, false)
                });
            }
        }
    }
}
