using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace TracsBusinessLogic
{
    //public class LegacyConfigurationProvider : ConfigurationProvider, IConfigurationSource
    //{
    //    public override void Load()
    //    {
    //        foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
    //        {
    //            Data.Add($"ConnectionStrings:{connectionString.Name}", connectionString.ConnectionString);
    //        }

    //        foreach (var settingKey in ConfigurationManager.AppSettings.AllKeys)
    //        {
    //            Data.Add(settingKey, ConfigurationManager.AppSettings[settingKey]);
    //        }
    //    }

    //    public IConfigurationProvider Build(IConfigurationBuilder builder)
    //    {
    //        return this;
    //    }
    //}
    public class AppConfig
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public ApiSettingsConfig ApiSettings { get; set; }

        public class ConnectionStringsConfig
        {
            public string MyDb { get; set; }
        }

        public class ApiSettingsConfig
        {
            public string Url { get; set; }
            public string ApiKey { get; set; }
            public bool UseCache { get; set; }
        }
    }
    public class ConfigTools
    {
        public static IConfiguration Configuration { get; set; }
        private static string getConfigFilePath()
        {
            return AppContext.BaseDirectory; // Assembly.GetExecutingAssembly().Location + ".config";
        }
       
        public static string GetConfigValue(string key, string default_value)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json.config", optional: true)
            //.Add(new LegacyConfigurationProvider())
            //.Build();
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appSettings.json")
                .Build();


            dynamic value = config[key];
            //dynamic value = ConfigurationManager.AppSettings[key];
            if (value == null) value = "";
            if (value.ToString() == "")
            {
                value = default_value;
                //ConfigTools.WriteConfigValue(key, value);
            }
            return value.ToString();
        }

        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                return null;
                //throw new Exception("No configuration file found.", e);
            }
        }

        public static void WriteConfigValue(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");

            if (node == null)
                //   throw new InvalidOperationException("appSettings section not found in config file.");
                return;

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("value", value);
                }
                else
                {
                    // key was not found so create the 'add' element 
                    // and set it's key/value attributes 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(getConfigFilePath());
            }
            catch
            {
                //throw;
            }
        }
    }
}