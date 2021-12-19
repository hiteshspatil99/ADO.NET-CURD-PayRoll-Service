
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class PayRollSqlConnection
    {
        private SqlConnection con;
        private void Conncection()
        {
            string CS = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(CS);
        }
        public bool AddEmployee(EmpPayrollModel obj)
        {
            Conncection();
            SqlCommand com = new SqlCommand("AddPayRoleServices", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name ", obj.name);
            com.Parameters.AddWithValue("@salary ", obj.salary);
            com.Parameters.AddWithValue("@start ", obj.start);
            com.Parameters.AddWithValue("@gender ", obj.gender);
            com.Parameters.AddWithValue("@PhoneNo ", obj.PhoneNo);
            com.Parameters.AddWithValue("@OfficeAddress ", obj.OfficeAddress);
            com.Parameters.AddWithValue("@Department ", obj.Department);
            com.Parameters.AddWithValue("@BasicPay", obj.BasicPay);
            com.Parameters.AddWithValue("@Deductions", obj.Deductions);
            com.Parameters.AddWithValue("@TaxablePay", obj.TaxablePay);
            com.Parameters.AddWithValue("@IncomeTax", obj.IncomeTax);
            com.Parameters.AddWithValue("@NetPay", obj.NetPay);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}