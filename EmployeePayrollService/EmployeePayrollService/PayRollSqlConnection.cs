
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class PayRollSqlConnection
    {
        List<EmpPayrollModel> PayrollList = new List<EmpPayrollModel>();

        private SqlConnection con;
        private void Connection()
        {
            string CS = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(CS);
        }
        public bool AddEmployee(EmpPayrollModel obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddPayRollService", con);
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
            com.Parameters.AddWithValue("@@Dept_id", obj.Dept_id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        //To view employee details with generic list     
        public List<EmpPayrollModel> GetAllEmployees()
        {
            Connection();


            SqlCommand com = new SqlCommand("GetPayrollServices", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable data = new DataTable();

            con.Open();  //open query for executing
            da.Fill(data);
            con.Close();  //Close query After executing

            foreach (DataRow dr in data.Rows) //Bind EmpPayrollModel generic list using dataRow  
            {

                PayrollList.Add
                    (new EmpPayrollModel
                    {

                        name = Convert.ToString(dr["name"]),
                        start = Convert.ToDateTime(dr["start"]),
                        gender = Convert.ToChar(dr["gender"]),
                        PhoneNo = Convert.ToDouble(dr["PhoneNo"]),
                        OfficeAddress = Convert.ToString(dr["OfficeAddress"]),
                        Department = Convert.ToString(dr["Department"]),
                        BasicPay = Convert.ToDouble(dr["BasicPay"]),
                        Deductions = Convert.ToDouble(dr["Deductions"]),
                        TaxablePay = Convert.ToDouble(dr["Taxablepay"]),
                        IncomeTax = Convert.ToDouble(dr["IncomeTax"]),
                        NetPay = Convert.ToDouble(dr["NetPay"]),
                    }
                    );
            }

            return PayrollList;
        }
        //To Update Employee details    
        public bool UpdateEmployee(EmpPayrollModel obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("UpdatePayrollServices", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", obj.name);
                com.Parameters.AddWithValue("@salary", obj.salary);
                com.Parameters.AddWithValue("@gender", obj.gender);
                com.Parameters.AddWithValue("@Department", obj.Department);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
             catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        //To Delete Employee details    
        public bool DeleteEmployee(int id)
        {
            try 
            {
                Connection();
                SqlCommand com = new SqlCommand("DeletePayrollServices	", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);

                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public void Display()
        {
            foreach (var item in PayrollList)
            {
                Console.WriteLine("\n name \t BasicPay \t \t start \t gender");
                Console.WriteLine(item.name + "\t" + item.BasicPay + "\t" + item.start + "\t" + item.gender);
            }
        }
    }
}