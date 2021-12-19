using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Pay Roll Service");

            PayRollSqlConnection paysql = new PayRollSqlConnection();
            EmpPayrollModel model = new EmpPayrollModel();

        }

    }
}
