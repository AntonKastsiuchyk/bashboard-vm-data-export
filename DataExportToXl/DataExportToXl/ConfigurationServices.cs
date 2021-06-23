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

        public string DashboardConnectionString { get; }

        public string BaseConnectionString { get; }

        public string PathXl { get; }

        public ConfigurationServices()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", true)
                .Build();

            DashboardConnectionString = _configuration.GetConnectionString("dashboard");
            BaseConnectionString = _configuration.GetConnectionString("base");

            PathXl = _configuration["PathXl"];
        }
    }
}
