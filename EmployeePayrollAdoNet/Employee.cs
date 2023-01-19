using EmployeePayrollAdoNet;
using Microsoft.Data.SqlClient;
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
        public int UpdateEmployee()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update Employee Set Salary = @Salary Where Name = @Name", this.sqlconnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Name", "Richu");

                sqlCommand.Parameters.AddWithValue("@Salary", "3000000");

                sqlconnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();

                return effectedRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public int UpdateEmployeeDetailsWithStoredProcedure()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployeeDetails", this.sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", "Richu");

                sqlCommand.Parameters.AddWithValue("@Salary", "3000000");

                sqlconnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();

                return effectedRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public void UpdateEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployeeDetails", this.sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give Name Of Employee You Want to Update Salary: ");
                string name = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Name", name);
                Console.Write("Give New Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Salary", salary);

                sqlconnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("-----Updated Successfully-----");
                }
                else
                    Console.WriteLine("-----Something Went Wrong-----");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public void DeleteEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeDetails", this.sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give EmpId To Delete: ");
                int empId = Convert.ToInt32(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);

                sqlconnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("-----Deleted Successfully-----");
                }
                else
                    Console.WriteLine("-----Something Went Wrong-----");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public List<Employee> RetrieveEmployeeDetailsBetweenDateRange()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployeeBetweenDateRange", sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give Date 1: ");
                DateTime date1 = Convert.ToDateTime(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Date1", date1);
                Console.Write("Give Date 2: ");
                DateTime date2 = Convert.ToDateTime(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Date2", date2);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlconnection.Open();
                sqlDataAdapter.Fill(dataTable);

                empList.Clear();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    empList.Add(
                        new EmployeeModel
                        {
                            Id = Convert.ToInt32(dataRow["Id"]),
                            Name = Convert.ToString(dataRow["Name"]),
                            Salary = Convert.ToInt32(dataRow["Salary"]),
                            Start = Convert.ToDateTime(dataRow["Startdate"]),
                            Gender = Convert.ToString(dataRow["Gender"]),
                            PhoneNumber = Convert.ToInt32(dataRow["Phone"]),
                            Address = Convert.ToString(dataRow["Address"]),
                            Department = Convert.ToString(dataRow["Department"])
                        }
                        );
                }
                return empList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public void DisplayDetails()
        {
            if ((empList.Count) > 0)
            {
                Console.WriteLine("________________________________________\n");
                foreach (EmployeeModel employeeModel in empList)
                {
                    Console.WriteLine("Employee Id: " + employeeModel.Id);
                    Console.WriteLine("Name: " + employeeModel.Name);
                    Console.WriteLine("Gender: " + employeeModel.Gender);
                    Console.WriteLine("Phone: " + employeeModel.PhoneNumber);
                    Console.WriteLine("Address: " + employeeModel.Address);
                    Console.WriteLine("Department: " + employeeModel.Department);
                    Console.WriteLine("Salary: " + employeeModel.Salary);
                    Console.WriteLine("StartDate: " + employeeModel.Start);
                    Console.WriteLine("________________________________________\n");
                }
            }
            else
            {
                Console.WriteLine("-----Data Not Found-----");
            }
        }
        public void AggregateFunctions()
        {
            try
            {
                sqlconnection.Open();
                Console.Write("\n1. Sum\n2. Minimum\n3. Maximum\n4. Average\n5. Count\n" +
                    "Please Select Which Functon You Need: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SqlCommand sqlCommand = new SqlCommand("spSumOfSalaryByGender", sqlconnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@Gender", gender);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Sum: {0}", reader[0]));
                        }
                        break;
                    case 2:
                        SqlCommand sqlCommand1 = new SqlCommand("spMinimumOfSalaryByGender", sqlconnection);
                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender1 = Console.ReadLine();
                        sqlCommand1.Parameters.AddWithValue("@Gender", gender1);
                        SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                        if (reader1.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Minimum: {0}", reader1[0]));
                        }
                        break;
                    case 3:
                        SqlCommand sqlCommand2 = new SqlCommand("spMaximumOfSalaryByGender", sqlconnection);
                        sqlCommand2.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender2 = Console.ReadLine();
                        sqlCommand2.Parameters.AddWithValue("@Gender", gender2);
                        SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                        if (reader2.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Maximum: {0}", reader2[0]));
                        }
                        break;
                    case 4:
                        SqlCommand sqlCommand3 = new SqlCommand("spAverageOfSalaryByGender", sqlconnection);
                        sqlCommand3.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender3 = Console.ReadLine();
                        sqlCommand3.Parameters.AddWithValue("@Gender", gender3);
                        SqlDataReader reader3 = sqlCommand3.ExecuteReader();
                        if (reader3.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Average: {0}", reader3[0]));
                        }
                        break;
                    case 5:
                        SqlCommand sqlCommand4 = new SqlCommand("spCountByGender", sqlconnection);
                        sqlCommand4.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender4 = Console.ReadLine();
                        sqlCommand4.Parameters.AddWithValue("@Gender", gender4);
                        SqlDataReader reader4 = sqlCommand4.ExecuteReader();
                        if (reader4.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Count: {0}", reader4[0]));
                        }
                        break;
                    default:
                        Console.WriteLine("________________________________________\n");
                        Console.WriteLine("-----Invalid Option-----");
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
