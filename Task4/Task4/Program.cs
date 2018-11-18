using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Task4.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Show the list of first and last names of the employees from London");
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE City='London';";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }
    }
}
