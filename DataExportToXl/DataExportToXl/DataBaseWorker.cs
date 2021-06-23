using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DataExportToXl
{
    class DataBaseWorker
    {
        internal void CreateDataBase()
        {
            string sqlExpression = "CREATE DATABASE dashboard";
            ConfigurationServices configuration = new ConfigurationServices();

            using (SqlConnection connection = new SqlConnection(configuration.BaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("DB was created.");
            }
        }

        internal void CreateTable()
        {
            string sqlExpression =
                "CREATE TABLE Products (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(20) NOT NULL," +
                "Description NVARCHAR(50) NOT NULL, Price SMALLMONEY NOT NULL)";

            ConfigurationServices configuration = new ConfigurationServices();

            using (SqlConnection connection = new SqlConnection(configuration.DashboardConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Table was created.");
            }
        }

        internal void InsertValuesIntoDb()
        {
            string insertExpression = "INSERT INTO Products VALUES" +
                                      "('Product1', 'Information 1', '10.00')," +
                                      "('Product2', 'Information 2', '20.00')," +
                                      "('Product3', 'Information 3', '30.00')," +
                                      "('Product4', 'Information 4', '40.00')," +
                                      "('Product5', 'Information 5', '50.00')," +
                                      "('Product6', 'Information 6', '60.00')," +
                                      "('Product7', 'Information 7', '70.00')," +
                                      "('Product8', 'Information 8', '80.00')," +
                                      "('Product9', 'Information 9', '90.00')";

            ConfigurationServices configuration = new ConfigurationServices();

            using (SqlConnection connection = new SqlConnection(configuration.DashboardConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(insertExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Values were added.");
            }
        }

        internal void UpdateValueInDb()
        {
            string updateExpression = "UPDATE Products SET Description = 'Information 0' WHERE Price = 90.00";

            ConfigurationServices configuration = new ConfigurationServices();

            using (SqlConnection connection = new SqlConnection(configuration.DashboardConnectionString))
            {
                connection.Open();
                SqlCommand commandUpdate = new SqlCommand(updateExpression, connection);
                commandUpdate.ExecuteNonQuery();

                Console.WriteLine("Updating completed successfully.");
            }
        }

        internal void DeleteValueInDb()
        {
            string deleteExpression = "DELETE FROM Products WHERE Description = 'Information 0'";
            ConfigurationServices configuration = new ConfigurationServices();

            using (SqlConnection connection = new SqlConnection(configuration.DashboardConnectionString))
            {
                connection.Open();
                SqlCommand commandDelete = new SqlCommand(deleteExpression, connection);
                commandDelete.ExecuteNonQuery();

                Console.WriteLine("Deleting completed successfully.");
            }
        }

        internal void CreateProcedureInDb()
        {
            string procedure = "CREATE PROCEDURE [dbo].[GetProducts] AS SELECT * FROM Products GO";
            ConfigurationServices configuration = new ConfigurationServices();

            using (SqlConnection connection = new SqlConnection(configuration.DashboardConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(procedure, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Procedure was added.");
            }
        }
    }
}