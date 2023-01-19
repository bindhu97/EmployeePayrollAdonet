using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdoNet
{
    public class Employee
    {
        public static void EmpDatabase()
        {
            SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = master; integrated security = true");
            try
            {
                string query = "Create Database EmployeePayroll";
                SqlCommand cm = new SqlCommand(query, con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Database created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
