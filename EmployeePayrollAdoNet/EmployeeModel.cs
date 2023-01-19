using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdoNet
{
    public class EmployeeModel
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static long Salary { get; set; }
        public static DateTime Start { get; set; }
        public static char Gender { get; set; }
        public static int PhoneNumber { get; set; }
        public static string Address { get; set; }
        public static string Department { get; set; }
        public static long BasicPay { get; set; }
        public static long Deductions { get; set; }
        public static long TaxablePay { get; set; }
        public static long IncomeTax { get; set; }
        public static long NetPay { get; set; }
    }
}
