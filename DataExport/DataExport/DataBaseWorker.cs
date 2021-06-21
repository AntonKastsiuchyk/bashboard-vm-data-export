using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExport
{
    class DataBaseWorker
    {
        internal void CreateDataBase(string connectionString)
        {
            string sqlExpression = "CREATE DATABASE bashboard";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("DB was created.");
            }
        }

        internal void CreateTable(string connectionString)
        {
            string sqlExpression =
                "CREATE TABLE Products (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(20) NOT NULL," +
                "Description NVARCHAR(50) NOT NULL, Price SMALLMONEY NOT NULL)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Table was created.");
            }
        }

        internal void InsertValuesIntoDb()
        {
            string insertExpression = "INSERT Products VALUES" +
                                      "('ProductOne', 'Information one', '10.00')," +
                                      "('ProductTwo', 'Information two', '20.00')," +
                                      "('ProductThree', 'Information three', '30.00')," +
                                      "('ProductFour', 'Information four', '40.00')," +
                                      "('ProductFive', 'Information five', '50.00')," +
                                      "('ProductSix', 'Information six', '60.00')," +
                                      "('ProductSeven', 'Information seven', '70.00')," +
                                      "('ProductEight', 'Information eight', '80.00')," +
                                      "('ProductNine', 'Information nine', '90.00')," +
                                      "('ProductTen', 'Information ten', '100.00')";

            using (SqlConnection connection = new SqlConnection(Constants.connectionStringBashboard))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(insertExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Values were added.");
            }
        }

        internal void UpdateValueInDb()
        {
            string updateExpression = "UPDATE Products SET Description = 'Information 0' WHERE Price = 100.00";

            using (SqlConnection connection = new SqlConnection(Constants.connectionStringBashboard))
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

            using (SqlConnection connection = new SqlConnection(Constants.connectionStringBashboard))
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

            using (SqlConnection connection = new SqlConnection(Constants.connectionStringBashboard))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(procedure, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Procedure was added.");
            }
        }
    }
}
