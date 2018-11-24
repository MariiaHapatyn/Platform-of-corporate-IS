using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Task
    {
        string connectionString;
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public void Task2()
        {
            //2. Show the list of first and last names of the employees from London.
            Console.WriteLine("Show the list of first and last names of the employees from London");
            command = connection.CreateCommand();
            command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE City='London';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }

        public void Task5()
        {
            // 5.Calculate the count of employees from London.
            Console.WriteLine("\nCalculate the count of employees from London");
            command.CommandText = "SELECT COUNT(*) AS EmployeeQuantity FROM Employees WHERE City='London';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["EmployeeQuantity"]);
            }
            reader.Close();
        }

        public void Task9()
        {
            //9.	Show the first and last name(s) of the eldest employee(s). 
            Console.WriteLine("\nShow the first and last name of the eldest employee");
            command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE BirthDate=(SELECT MIN(BirthDate) FROM Employees) GROUP BY LastName, FirstName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }

        public void Task12()
        {
            //12.	Show first, last names and dates of birth of the employees who celebrate their birthdays this month.
            Console.WriteLine("\nShow first, last names and dates of birth of the employees who celebrate their birthdays this month");
            command.CommandText = "SELECT LastName, FirstName  FROM Employees WHERE MONTH(BirthDate)=(MONTH(getdate())) GROUP BY LastName, FirstName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }

        public void Task14()
        {
            //14.	Show first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join).
            Console.WriteLine("\nShow first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join)");
            command.CommandText = "SELECT e.FirstName, e.LastName, COUNT(o.EmployeeID) AS OrdersQuantity FROM Employees AS e LEFT JOIN Orders AS o ON o.EmployeeID=e.EmployeeID WHERE o.OrderDate>='1997-01-01' AND o.OrderDate<='1997-12-31' GROUP BY e.FirstName, e.LastName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-10}{1,-10}{2}", reader["FirstName"], reader["LastName"], reader["OrdersQuantity"]);
            }
            reader.Close();
        }

        public void Task18()
        {
            //18.	Show the list of french customers’ names who have made more than one order (use grouping).
            Console.WriteLine("\nShow the list of french customers’ names who have made more than one order (use grouping)");
            command.CommandText = "SELECT c.ContactName FROM Customers AS c, Orders AS o WHERE c.Country='France' GROUP BY c.ContactName HAVING COUNT(o.CustomerID)>1;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }

        public void Task24()
        {
            //24.	*Show the list of french customers’ names who used to order french products.
            Console.WriteLine("\nShow the list of french customers’ names who used to order french products");
            command.CommandText = "SELECT c.ContactName FROM Customers AS c, Orders AS o WHERE c.CustomerID=o.CustomerID AND c.Country='France' AND o.ShipCountry='France';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }

        public void Task25()
        {
            //25.	*Show the total ordering sum calculated for each country of customer.
            Console.WriteLine("\nShow the total ordering sum calculated for each country of customer");
            command.CommandText = "SELECT c.Country, SUM(od.UnitPrice) AS TotalPrice FROM Customers AS c, Orders AS o, [Order Details] AS od WHERE o.CustomerID=c.CustomerID AND o.OrderID=od.OrderID GROUP BY c.Country;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-10}{1}", reader["Country"], reader["TotalPrice"]);
            }
            reader.Close();
        }

        public void Task31()
        {
            ////31.	*Insert 5 new records into Employees table. Fill in the following  fields: LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes. The Notes field should contain your own name.
            int insertQuantity = 0;
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Pachva', 'Natalia', '1999-07-06', '2018-11-19', 'Shevchenka st. 78', 'Lviv', 'Ukraine', 'Natalia');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Hapatyn', 'Mariia', '1999-11-14', '2018-11-19', 'Bandery st. 8', 'Lviv', 'Ukraine', 'Natalia');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Shcherbak', 'Andriana',  '1999-09-08', '2018-11-19', 'Lubin st. 73', 'Lviv', 'Ukraine', 'Natalia');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Pastu', 'Olya',  '1999-01-25', '2018-11-19', 'Stryiska st. 18', 'Lviv', 'Ukraine', 'Natalia');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Dubyk', 'Andriy',  '1999-09-07', '2018-11-19', 'Naukova st. 16', 'Lviv', 'Ukraine', 'Natalia');";
            insertQuantity += command.ExecuteNonQuery();
            Console.WriteLine("\nInserted {0} rows", insertQuantity);
        }

        public void Task35()
        {
            ////35. * Delete one of your records.
            int deletedQuantity = 0;
            command.CommandText = "DELETE FROM Employees WHERE LastName='Shcherbak' AND FirstName='Andriana';";
            deletedQuantity += command.ExecuteNonQuery();
            Console.WriteLine("Deleted {0} rows", deletedQuantity);
            connection.Close();
        }

        public void DoTasks()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Task4.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            Task2();
            Task5();
            Task9();
            Task12();
            Task14();
            Task18();
            Task24();
            Task25();
            Task31();
            Task35();
        }
    }
}
