using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataExportToXl
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationServices configuration = new ConfigurationServices();

            DataBaseWorker dataBaseWorker = new DataBaseWorker(configuration, "dashboard");

            Serializer serializer = new Serializer(configuration, "PathXl");

            serializer.SerializeToXml(dataBaseWorker.GetProducts());
        }
    }
}
