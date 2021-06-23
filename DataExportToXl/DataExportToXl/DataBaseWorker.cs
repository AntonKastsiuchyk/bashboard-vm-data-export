using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DataExportToXl
{
    class DataBaseWorker
    {
        private string _connectionString;

        internal void ExecuteSqlExpression(string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Successfully.");
            }
        }

        internal List<Product> GetProducts()
        {
            string spGetProducts = "GetProducts";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(spGetProducts, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    List<Product> products = new List<Product>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.Description = reader.GetString(2);
                                product.Price = reader.GetDecimal(3);

                                products.Add(product);
                            }
                        }
                    }

                    Console.WriteLine("Products were added.");
                    return products;
                }
            }
        }

        public DataBaseWorker(ConfigurationServices configuration, string keyConnectionString)
        {
            while (String.CompareOrdinal(_connectionString, configuration.BaseConnectionString) == 0 
                   || String.CompareOrdinal(_connectionString, configuration.DashboardConnectionString) == 0
                   || string.IsNullOrEmpty(_connectionString))
            {
                if (keyConnectionString.Equals("dashboard", StringComparison.Ordinal))
                {
                    _connectionString = configuration.DashboardConnectionString;
                    return;
                }

                if (keyConnectionString.Equals("base", StringComparison.Ordinal))
                {
                    _connectionString = configuration.BaseConnectionString;
                    return;
                }

                Console.WriteLine("Unknown connection string. Please input correct key.");
                keyConnectionString = Console.ReadLine();
            }
        }
    }
}