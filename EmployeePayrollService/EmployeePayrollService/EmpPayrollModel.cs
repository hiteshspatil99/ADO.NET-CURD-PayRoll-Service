using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmpPayrollModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public float salary { get; set; }
        public  DateTime start { get; set; }
        public char gender { get; set; }
        public double PhoneNo { get; set; }
        public string OfficeAddress { get; set; }
        public string Department { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        public String Dept_id { get; set; }
    }
}
