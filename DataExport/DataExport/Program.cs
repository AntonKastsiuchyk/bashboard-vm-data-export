using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace DataExport
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeToXml(GetProducts());
        }

        internal static List<Product> GetProducts()
        {
            string spGetProducts = "GetProducts";

            using (SqlConnection connection = new SqlConnection(Constants.connectionStringBashboard))
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

        internal static void SerializeToXml(List<Product> listOfObjects)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fileStream = new FileStream("D:\\products.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, listOfObjects);
            }

            Console.WriteLine("Serialization completed successfully.");
        }
    }
}
