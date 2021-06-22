using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace DataExportToXl
{
    class ConfigurationServices
    {
        private static IConfigurationRoot _configuration;

        public static string GetConnString(string connectionStringKey)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", true)
                .Build();

            string connectionStringValue = _configuration.GetConnectionString(connectionStringKey);
            return connectionStringValue;
        }

        public static string GetPath()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", true)
                .Build();

            string path = _configuration["PathXL"];
            return path;
        }
    }
}
