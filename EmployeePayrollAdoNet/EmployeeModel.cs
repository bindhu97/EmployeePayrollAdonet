using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollAdoNet
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public DateTime Start { get; set; }
        public char Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public long BasicPay { get; set; }
        public long Deductions { get; set; }
        public long TaxablePay { get; set; }
        public long IncomeTax { get; set; }
        public long NetPay { get; set; }
    }
}
