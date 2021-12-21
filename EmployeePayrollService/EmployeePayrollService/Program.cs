using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Pay Roll Service");

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Select the number which is to be executed \n 1.ADD \n 2.Delete \n 3.Update  \n 4.View \n 5.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                PayRollSqlConnection paysql = new PayRollSqlConnection();
                switch (choice)
                {
                    case 1:
                        EmpPayrollModel model = new EmpPayrollModel();
                     
                        model.name = "Ritesh";
                        model.start = DateTime.Now;
                        model.salary = 80000;
                        model.gender = 'M';
                        model.PhoneNo = 8967453272;
                        model.OfficeAddress = "Pune";
                        model.Department = "Sales";
                        model.BasicPay = 71769;
                        model.Deductions = 4681.56;
                        model.TaxablePay = 400.45;
                        model.IncomeTax = 225.34;
                        model.NetPay = 80000;
                        model.Dept_id = 1;

                       

                        var result = paysql.AddEmployee(model);

                        if (result != null)

                            Console.WriteLine("Data is added Successfully");
                        else
                            Console.WriteLine("Correct Data as per given Column Sequence");
                        break;

                    case 2:
                        Console.WriteLine("Enter the id To Delete Data");
                        int num = Convert.ToInt32(Console.ReadLine());
                        paysql.DeleteEmployee(num);
                        break;


                    case 3:
                        flag = false;
                        break;
                }
            }
        }
    }
}