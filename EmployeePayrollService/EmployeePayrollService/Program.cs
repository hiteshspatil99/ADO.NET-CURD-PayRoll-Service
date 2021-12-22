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
                EmpPayrollModel model = new EmpPayrollModel();

                switch (choice)
                {
                    case 1:
                   
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
                        string name = "Nitesh";
                        DateTime start = DateTime.Now;
                        float salary = 95000;                  // It Will Updating the thing described
                        char gender = 'M'; 
                        paysql.UpdateEmployee(name, start, salary, gender);
                        break;

                    case 4:
                        flag = false;
                        break;
                }
            }
        }
    }
}