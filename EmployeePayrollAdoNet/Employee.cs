using EmployeePayrollAdoNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdoNet
{
    public class Employee
    {
        public static string connectionString = @"data source = (localdb)\\\\MSSQLLocalDB; initial catalog = master; integrated security = true\";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        public static void EmpDatabase()
        {
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
        public int AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    SqlCommand command = new SqlCommand("spAddEmployee", this.sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeeModel.Name);
                    command.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Department", employeeModel.Department);
                    command.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", employeeModel.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    int result = command.ExecuteNonQuery();
                    this.sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Added Successfully");
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
