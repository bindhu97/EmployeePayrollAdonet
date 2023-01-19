using EmployeeAdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollAdoNet
{
    public class program
    {
        public static void Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("Welcome to AdoDotNet Database Program");
                Console.WriteLine("1) Create Database\n");
                int result = (int)Convert.ToInt64(Console.ReadLine());
                switch (result)
                {
                    case 1:
                        Employee.EmpDatabase();
                        break;
                }
            }
        }
    }
}
