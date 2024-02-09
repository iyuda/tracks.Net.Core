﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace TracsBusinessLogic
{
    public static class Logger
    {
        public static string GetProperErrorMessage(string Message, bool apiError)
        {

            if (!apiError || String.IsNullOrEmpty(Message))
                return "There was an error processing your request.  Please try again later.";
            else
                return (Message ?? "").ToLower().Contains("token") ? "Please log in again to use the application" : Message;
        }
        public static string GetLogsDirectory(string Area ="")
        {
            if (Area != "")
                Area =  Area + "\\";
            string LogsDirectory = AppDomain.CurrentDomain.BaseDirectory + Area + "Logs\\" +
                                 DateTime.Now.ToString("dddd") + "\\";
            try
            {
                if (!Directory.Exists(LogsDirectory)) Directory.CreateDirectory(LogsDirectory);
                if (Directory.GetLastWriteTime(LogsDirectory).Date != DateTime.Now.Date)
                {
                    foreach (string dir in Directory.GetDirectories(LogsDirectory))
                    {
                        try
                        {
                            Directory.Delete(dir, true);
                        }
                        catch { }
                    }
                    foreach (string file in Directory.GetFiles(LogsDirectory))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch { }
                    }
                    File.WriteAllText(LogsDirectory + "Conttrol.txt", "");
                }

                if (!Directory.Exists(LogsDirectory)) Directory.CreateDirectory(LogsDirectory);
            }
            catch (Exception ex) { }
            return LogsDirectory;
        }
        
        public static string LogActivity(string strMessage, string LogFileName = "Activity", string Area="")
        {
            bool IsService = true;
            if (System.Environment.GetCommandLineArgs().Length > 1)
                if (System.Environment.GetCommandLineArgs()[1] == "debug")
                    IsService = false;

            string LogsDirectory = GetLogsDirectory(Area);


            if (LogFileName != "")
                LogFileName = LogsDirectory + LogFileName + ".log";
            else
                LogFileName = LogsDirectory + "Exceptions.log";

            string Outstring = strMessage;// +System.Environment.NewLine;
            File.AppendAllText(LogFileName, DateTime.Now + System.Environment.NewLine + Outstring + System.Environment.NewLine);
            Outstring = (IsService ? "" : (DateTime.Now + System.Environment.NewLine)) + Outstring;
            if (LogFileName.Contains("Activity"))
            {
                if (!IsService) Console.WriteLine(Outstring);

                //nlogger.Debug(Outstring);
                //nlogger.Info(Outstring);
            }
            return Outstring;
        }

        public static string LogAction(string strMessage, string LogFileName = "ActionQueries", string Area = "")
        {
            string LogsDirectory = GetLogsDirectory(Area);

            if (LogFileName != "")
                LogFileName = LogsDirectory + LogFileName + ".log";
            else
                LogFileName = LogsDirectory + "Exceptions.log";

            string Outstring = System.Environment.NewLine + DateTime.Now + System.Environment.NewLine + strMessage + System.Environment.NewLine;
            File.AppendAllText(LogFileName, Outstring);
            return Outstring;
        }
        public static string LogError(string strMessage, string LogFileName = "Errors", string Area = "")
        {

            string LogsDirectory = GetLogsDirectory(Area);

            if (LogFileName != "")
                LogFileName = LogsDirectory + LogFileName + ".log";
            else
                LogFileName = LogsDirectory + "Exceptions.log";
            string Outstring = System.Environment.NewLine + DateTime.Now + System.Environment.NewLine + strMessage + System.Environment.NewLine;
            File.AppendAllText(LogFileName, Outstring);
            return Outstring;
        }

        public static string LogException(Exception e, string LogFileName = "", string AdditionalMsg = "", string Area = "")
        {
            string strMessage = AdditionalMsg;
            string strStackTrace = "Stack trace: ";
            string strSource = "Source: ";

            if (e.InnerException != null)
            {
                strMessage += e.InnerException.Message.Trim();
                if (e.InnerException.StackTrace != null) strStackTrace += e.InnerException.StackTrace.Trim();
                if (e.InnerException.Source != null) strSource += e.InnerException.Source.Trim();

            }
            else
            {
                strMessage += System.Environment.NewLine + e.Message.Trim();
                if (e.StackTrace != null) strStackTrace += e.StackTrace.Trim();
                if (e.Source != null) strSource += e.Source.Trim();

            }
            string LogsDirectory = GetLogsDirectory(Area);

            if (LogFileName != "")
                LogFileName = LogsDirectory + LogFileName + ".log";
            else
                LogFileName = LogsDirectory + "Exceptions.log";
            //"Connection string: " + DbConnect.ConnectionString +  
            string Outstring = System.Environment.NewLine + DateTime.Now + System.Environment.NewLine + strMessage + ":" + System.Environment.NewLine + strStackTrace + System.Environment.NewLine + strSource + System.Environment.NewLine;
            File.AppendAllText(LogFileName, Outstring);
            return Outstring;
        }
    }
}