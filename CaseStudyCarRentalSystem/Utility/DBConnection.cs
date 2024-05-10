using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Utility
{
    internal class DBConnection
    {
        private static IConfiguration _iconfiguration;
        //constructor
        static DBConnection()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }



    }
}