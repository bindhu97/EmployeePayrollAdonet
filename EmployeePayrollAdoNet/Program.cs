using EmployeeAdoNet;

namespace EmployeePayrollAdoNet
{
    public class program
    {
        public static void Main(string[] args)
        {
            Employee employee = new Employee();
            Employee.EmpDatabase();
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Bindhu";
            employeeModel.Salary = 23000;
            employeeModel.Gender = 'F';
            employeeModel.Address = "Dasanpura";
            employeeModel.PhoneNumber = "5977665422";
            employeeModel.Department = "Sales";
            employeeModel.BasicPay = 150000;
            employeeModel.Deductions = 1000;
            employeeModel.TaxablePay = 1000;
            employeeModel.IncomeTax = 1000;
            employeeModel.NetPay = 12000;

            employee.AddEmployee(employeeModel);
            employeeModel.Name = "Bindhu";
            employeeModel.Address = "Chikpete";
            employeeModel.PhoneNumber = "786754344325";

            employee.UpdateEmployee();
        }
    }
}