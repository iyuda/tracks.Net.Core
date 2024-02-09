using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using StaticHttpContextAccessor.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Tracs.Common.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using StaticHttpContextAccessor.Helpers;

namespace TracsBusinessLogic
{
    public static class CommonFunctions
    {


        public static int? GetStateId(string name)
        {

            Tuple<HttpResponseMessage, string> stateResponse = ApiHelper.UrlRequest(RmaEndpoints.EP_States, "GET");
            JArray data = (JArray)JsonMaker.GetJsonExtract(stateResponse.Item2, "$.data");
            foreach (var item in data)
            {
                var state = item.ToObject<StateModel>();
                if (state.Name.Equals(name))
                {
                    return state.StateId;
                }
            }

            return 0;
        }

        public static List<StateModel> GetStatesByCountry(string countryId)
        {

            bool apiError = false;
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_States, parameters: new List<string> { countryId }, method: "GET");

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
                        List<StateModel> states = new List<StateModel>();
                        foreach (JToken item in data)
                        {
                            states.Add(item.ToObject<StateModel>());
                        }
                        return states;

                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        apiError = true;
                        throw new ApplicationException(message);
                    }
                }
            }

            catch (WebException ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex);
                return new List<StateModel>();

            }
            catch (Exception ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex); return new List<StateModel>();
            }

        }


        public static List<CountryModel> GetCountries()
        {
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_Countries, "GET");

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    return new List<CountryModel>() { new CountryModel() { CountryId = 0, Name = "Error getting Country list" } };
                    throw new ApplicationException();
                }
                else
                {
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        List<CountryModel> countries = new List<CountryModel>();
                        foreach (JToken item in data)
                        {
                            countries.Add(item.ToObject<CountryModel>());
                        }
                        if ((CountryModel.fullList?.Count ?? 0) == 0)
                            CountryModel.fullList = countries;

                        return countries;
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();

                        return new List<CountryModel>() { new CountryModel() { CountryId = 0, Name = message } };
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex); return null;
            }
        }

        public static List<StateModel> GetStates(string Token = null, List<string> parameters = null)
        {
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_States, "GET", parameters: parameters);

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    return new List<StateModel>() { new StateModel() { StateId = 0, Name = "Error getting state list" } };
                    throw new ApplicationException();
                }
                else
                {
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        List<StateModel> states = new List<StateModel>();
                        foreach (JToken item in data)
                        {
                            states.Add(item.ToObject<StateModel>());
                        }
                        if ((BLLAppContextExt.Current.Session.Get<List<StateModel>>("States")?.Count ?? 0) == 0)
                            BLLAppContextExt.Current.Session.Set<List<StateModel>>("States", states);

                        return states;
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();

                        return new List<StateModel>() { new StateModel() { StateId = 0, Name = message } };
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex); return null;
            }
        }
        public static List<FirmModel> GetFirms()
        {
            List<FirmModel> firms = (List<FirmModel>)BLLAppContextExt.Current.Items["GetFirms"];
            if (firms != null)
            {
                return firms;
            }
            bool apiError = false;
            try
            {


                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_Firms, "GET");

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    string message = null;
                    try
                    {
                        message = JObject.Parse(strResponseMsg)?["message"]?.ToString() ?? "";
                    }
                    catch
                    {

                    }
                    apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        //List<Firm> firms = data.ToObject<List<Firm>>();
                        firms = new List<FirmModel>();
                        foreach (JToken item in data)
                        {
                            FirmModel firm = item.ToObject<FirmModel>();
                            firm.id = int.Parse(item["FirmId"].ToString());
                            firms.Add(firm);
                        }
                        BLLAppContextExt.Current.Items["GetFirms"] = firms;
                        return firms;
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        //ModelState.AddModelError("", message);

                        apiError = true;
                        throw new Exception(message);
                    }
                }
            }
            catch (Exception ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", JsonConvert.SerializeObject(Logger.GetProperErrorMessage(ex.Message, apiError)));
                Logger.LogException(ex); return new List<FirmModel>();
            }
        }
        public static UserProfileModel GetUserProfile(string UserId, bool ShippingProfile = false)
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
                            userProfile.Firms = GetFirms();
                            userProfile.Countries = GetCountries();
                            userProfiles.Add(userProfile);
                        }
                        if (!ShippingProfile)
                            GetDefaultAddress(UserId, ref userProfiles);
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


        public static int GetDefaultAddress(string UserId, ref List<UserProfileModel> Users)
        {

            List<ReturnAddressModel> lstReturnAddresses = GetReturnAddresses(UserId);
            if (lstReturnAddresses.Count == 0)
                lstReturnAddresses.Add(new ReturnAddressModel());
            ReturnAddressModel defAddress = lstReturnAddresses.FirstOrDefault(x => x.IsDefault) ?? lstReturnAddresses[0];

            Users[0].ReturnAddressId = defAddress.ReturnAddressId;
            Users[0].ProfileStateId = defAddress.ReturnStateId;
            Users[0].ProfileCountryId = defAddress.ReturnCountryId;
            Users[0].StateName = defAddress.StateName;
            Users[0].StreetAddress = defAddress.Street;
            Users[0].City = defAddress.City;
            Users[0].Zip = defAddress.ZipCode;
            Users[0].UserId = UserId;
            return lstReturnAddresses.Count;



        }
        public static List<ReturnAddressModel> GetReturnAddresses(string UserId)
        {
            //List<ReturnAddressModel> lstReturnAddresses = (List<ReturnAddressModel>)BLLAppContextExt.Current.Items["ReturnAddresses"];
            //if (lstReturnAddresses != null)
            //{
            //    return lstReturnAddresses;
            //}

            bool apiError = false;
            try
            {
                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_GetReturnAddress, "GET", parameters: new List<string> { UserId });

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
                        List<ReturnAddressModel> ReturnAddresses = new List<ReturnAddressModel>();
                        foreach (JToken item in data)
                        {
                            ReturnAddressModel returnAddress = item.ToObject<ReturnAddressModel>();
                            returnAddress.id = int.Parse(item["ReturnAddressId"].ToString());
                            returnAddress.IsDefault = (bool)item["IsDefault"];
                            returnAddress.Street = item["Street"].ToString();
                            returnAddress.ZipCode = item["ZipCode"].ToString();
                            if (!ReturnAddresses.Exists(i => i.id == returnAddress.id))
                                ReturnAddresses.Add(returnAddress);
                        }
                        BLLAppContextExt.Current.Items["ReturnAddresses"] = ReturnAddresses;
                        return ReturnAddresses;
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();

                        Logger.LogActivity(message);
                        apiError = true;
                        throw new Exception(message);
                    }
                }
            }
            catch (Exception ex)
            {
                BLLAppContextExt.Current.Session.SetString("LoadPageErrors", Logger.GetProperErrorMessage(ex.Message, apiError));
                Logger.LogException(ex); return new List<ReturnAddressModel>();
            }
        }

        public static object UserProfileUpdate(UserProfileModel model)
        {

            bool apiError = false;
            try
            {

                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(RmaEndpoints.EP_UpdateProfile, "PUT", data: JsonConvert.SerializeObject(model));


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
                    var status = JObject.Parse(strResponseMsg)?["status"]?.ToString() ?? "0";
                    if (int.Parse(status) == 1)
                    {
                        JArray data = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                        JToken jsonToken = data?[0];
                        UserModel user = jsonToken?.ToObject<UserModel>();
                        user.id = int.Parse(jsonToken?["UserId"].ToString());
                        //HttpContext.Session.SetString("UserId", user.id?.ToString());

                        //HttpContext.Session.SetString("UserId", user.id?.ToString());
                        //HttpContext.Session.SetString("UserName", user.Name?.ToString());
                        //HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));


                        //HttpContext.Session.SetString("FirmTypeId", jsonToken?["FirmTypeId"]?.ToString());

                        //HttpContext.Session.SetString("Email", model.Email);
                        //HttpContext.Session.SetString("Phone", model.Phone);
                        //HttpContext.Session.SetString("FirmName", user.FirmName);
                        //HttpContext.Session.SetString("FirmId", model.FirmId);
                        return user;
                    }
                    else
                    {
                        string message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                        return message;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return (Logger.GetProperErrorMessage(ex.Message, apiError));
            }
        }
        public static JObject PostAddress<T>(T model, string Endpoint)
        {
            bool apiError = false;
            try
            {
                if (model.GetType().Name != "CompanyBranchModel")
                {
                    model.GetType().GetProperties().FirstOrDefault(p => p.Name == "UserId").SetValue(model, BLLAppContextExt.Current.Session.Get<string>("UserId"));
                }


                Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(Endpoint, "POST", data: JsonConvert.SerializeObject(model));
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
                    //throw new Exception(message);
                    return JObject.Parse(strResponseMsg);
                }
            }
            catch (Exception ex)
            {

                Logger.LogException(ex);
                return new JObject(new JProperty("status", 0), new JProperty("message", Logger.GetProperErrorMessage(ex.Message, apiError)));
            }

        }
    }
}
