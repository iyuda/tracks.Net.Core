using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Tracs.Common;
using StaticHttpContextAccessor.Helpers;

namespace TracsBusinessLogic
{
    public static class ApiHelper
    {
        public static string UserInfo { get; set; }

        public static JArray ExtractJsonData(string action, List<string> parameters)
        {
            JArray dataJson = null;
            try
            {
                //WebHeaderCollection _token = new WebHeaderCollection() { { "Token", Token } };
                //var userInfo = ClientDetection.GetUserEnvironment(Request);
                //Tuple<HttpResponseMessage, string> response = ApiHelper.UrlRequest(userinfo, action, "GET", parameters: parameters, WebHeaders: _token);
                Tuple<HttpResponseMessage, string> response = UrlRequest(action, "GET", parameters: parameters);

                HttpResponseMessage objResponseMsg = response.Item1;
                string strResponseMsg = response.Item2;

                if (objResponseMsg.StatusCode != HttpStatusCode.OK)
                {
                    var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                    //apiError = true;
                    throw new ApplicationException(message);
                }
                else
                {
                    var status = (JsonMaker.GetJsonExtract(strResponseMsg, "$.status") ?? "").ToString();
                    if (status.ToString() == "1")
                    {
                        dataJson = (JArray)JsonMaker.GetJsonExtract(strResponseMsg, "$.data");
                    }
                    else
                    {
                        var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();

                        throw new Exception(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return dataJson;
        }
        public static ResponseResult ApiPost(string action, string postData)
        {
            //WebHeaderCollection _token = new WebHeaderCollection() { { "Token", Token } };
            ResponseResult result = new ResponseResult();
            Tuple<HttpResponseMessage, string> response = UrlRequest(action, "POST", data: postData);

            HttpResponseMessage objResponseMsg = response.Item1;
            string strResponseMsg = response.Item2;
            if (objResponseMsg.StatusCode != HttpStatusCode.OK)
            {
                var message = (JsonMaker.GetJsonExtract(strResponseMsg, "$.message") ?? "").ToString();
                if (String.IsNullOrEmpty(message))
                    message = "There was an error processing your request";
                result.ResultMessage = message;
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.ResultMessage = strResponseMsg;
            }

            return result;
        }
        public static Tuple<HttpResponseMessage, string> UrlRequest(string Action, string method = "POST", List<string> parameters = null, string content_type = "application/json", string data = null, WebHeaderCollection WebHeaders = null, bool NoAuthorization = false)
        {
            string baseURL = "http://rma.parabit.com:1340/api/v1";// ConfigTools.GetConfigValue("API Base URL", "http://rma.paralan.us:1340/api/v1");
            var userInfo = ApiHelper.GetUserEnvironment(BLLAppContextExt.Current.Request.Headers["User-Agent"].ToString());// "Chrome 72.0 / Windows 10";// GetUserEnvironment(new HttpRequestWrapper(System.Web.HttpContext.Current.Request));
            string url = baseURL + "/" + Action + "/";
            try
            {
                if (parameters != null)
                    foreach (string parameter in parameters)
                    {
                        if (parameter!=null)
                            url += parameter + "/";
                    }

                Logger.LogAction("UrlRequest for: " + url + " method: " + method, "Activity");
                Logger.LogAction(url, "Endpoints");

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = method;

                if (WebHeaders == null)
                    WebHeaders = new WebHeaderCollection();
                if (!WebHeaders.AllKeys.Contains("Platform"))
                    WebHeaders.Add("Platform", "Web - " + userInfo);


                if (!WebHeaders.AllKeys.Contains("Token") || WebHeaders["Token"] == null)
                    WebHeaders.Add("Token", BLLAppContextExt.Current.Session.GetString("Token")?.ToString());
                webRequest.Headers = WebHeaders;
                webRequest.ContentType = content_type;

                if (data != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                }
                System.Diagnostics.Stopwatch timer = new Stopwatch();
                timer.Start();
                WebResponse response = webRequest.GetResponse();
                timer.Stop();

                StreamReader reader = new StreamReader(response.GetResponseStream());
                string ResponseString = reader.ReadToEnd();

                HttpResponseMessage response_msg = new HttpResponseMessage(HttpStatusCode.OK);

                response_msg.Content = new StringContent(ResponseString, Encoding.UTF8, "application/json"); //multipart/form-data

                Logger.LogAction(ResponseString, "Activity");
                return Tuple.Create(response_msg, ResponseString);

            }
            catch (WebException ex)
            {
                Logger.LogException(ex, AdditionalMsg: url + " " + method);

                if (ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    HttpResponseMessage response_msg = new HttpResponseMessage(resp.StatusCode);
                    using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        var ResponseString = sr.ReadToEnd();
                        Logger.LogAction(ResponseString, "Activity");
                        return Tuple.Create(response_msg, ResponseString);
                    }

                }
                else
                {
                    HttpResponseMessage response_msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    response_msg.Content = new StringContent(ex.Message, Encoding.UTF8, "text/plain");
                    return Tuple.Create(response_msg, ex.Message);
                }

            }

            catch (Exception ex)
            {
                Logger.LogException(ex);
                var response_msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response_msg.Content = new StringContent(ex.Message, Encoding.UTF8, "text/plain");

                return Tuple.Create(response_msg, ex.Message);
            }

        }

        public static String GetUserEnvironment(string ua)
        {
            var browser = GetUserBrowserInfo(ua);
            var platform = GetUserPlatform(ua);
            //var version = "72.0";// GetMobileVersion();
            return string.Format("{0} / {1}", browser, platform);
        }
        public static String GetUserBrowser(string ua)
        {
            if (ua.Contains("Chrome"))
                return "Chrome";
            if (ua.Contains("IE"))
                return "IE";

            return ua;
        }
        public static String GetUserBrowserInfo(string userAgent)
        {
            if (userAgent.Contains("MSIE 5.0"))
                return "Internet Explorer 5.0";
            else if (userAgent.Contains("MSIE 6.0"))
                return "Internet Explorer 6.0";
            else if (userAgent.Contains("MSIE 7.0"))
                return "Internet Explorer 7.0";
            else if (userAgent.Contains("MSIE 7.0b"))
                return "Internet Explorer 7.0b";
            else if (userAgent.Contains("MSIE 8.0"))
                return "Internet Explorer 8.0";
            else if (userAgent.Contains("MSIE 9.0"))
                return "Internet Explorer 9.0";
            else if (userAgent.Contains("MSIE 10.0"))
                return "Internet Explorer 10.0";
            else if (userAgent.Contains("MSIE 10.6"))
                return "Internet Explorer 10.6";
            else if (userAgent.Contains("MSIE 11"))
                return "Internet Explorer 11";

            else if (userAgent.Contains("Firefox"))
                return userAgent.Substring(userAgent.IndexOf("Firefox")).Replace("/", " ");
            else if (userAgent.Contains("Opera"))
                return userAgent.Substring(userAgent.IndexOf("Opera"));
            else if (userAgent.Contains("Chrome"))
            {
                string agentPart = userAgent.Substring(userAgent.IndexOf("Chrome"));
                return agentPart.Substring(0, agentPart.IndexOf("Safari") - 1).Replace("/", " ");
            }
            else if (userAgent.Contains("Safari"))
            {
                string agentPart = userAgent.Substring(userAgent.IndexOf("Version"));
                string version = agentPart.Substring(0, agentPart.IndexOf("Safari") - 1).Replace("Version/", "");
                return "Safari " + version;
            }
            else if (userAgent.Contains("Konqueror"))
            {
                string agentPart = userAgent.Substring(userAgent.IndexOf("Konqueror"));
                return agentPart.Substring(0, agentPart.IndexOf(";")).Replace("/", " ");
            }
            else if (userAgent.ToLower().Contains("bot") || userAgent.ToLower().Contains("search"))
                return "Search Bot";
            else if (userAgent.Contains("Trident"))
                return "Internet Explorer 11";
            return "Unknown Browser or Bot";
            
        }
        public static String GetUserPlatform(string ua)
        {
            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";

            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

            if (ua.Contains("Mac OS"))
                return "Mac OS";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                return "Windows 10";

            ////fallback to basic platform:
            //return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
            return ua;
        }
        public static String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }
    }
}
