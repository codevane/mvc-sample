using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace HRM
{
    // Requires NuGet package 
    // 1. Microsoft.Extensions.Configuration.Json
    // 2. Microsoft.Extensions.Configuration.Binder
    
    public class ConfigurationService
    {       
        public static IConfigurationRoot Configuration;
   
        public static void SetConfiguration()
        {
            Configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
        }

        public static T GetConfigurationValue<T>(string sectionName)
        {
            T @object = Configuration.GetSection(sectionName).Get<T>();
            return @object;
        }
        
        public static string GetConfigurationValue(string key)
        {
            string value = Configuration.GetValue<string>(key);
            return value;
        }

    }
}