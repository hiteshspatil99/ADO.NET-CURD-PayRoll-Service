
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
            try
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
                com.Parameters.AddWithValue("@Dept_id", obj.Dept_id);

                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        //To view employee details with generic list     
        
        
        //To Update Employee details    
        public bool UpdateEmployee(string name, DateTime start,float salary, char gender)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("UpdatePayrollServices", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@start", start);
                com.Parameters.AddWithValue("@salary", salary);
                com.Parameters.AddWithValue("@gender", gender);
                
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
                SqlCommand com = new SqlCommand("DeletePayrollServices", con);

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
        public DataSet   GetAllEmployees()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("GetPayrollServices", con);

                com.CommandType = CommandType.StoredProcedure;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("GetPayrollServices", this.con);
                adapter.Fill(dataSet, "employee_payroll");

                foreach (DataRow dr in dataSet.Tables["employee_payroll"].Rows)
                {
                    Console.WriteLine("\t" + dr["id"] + " " + dr["name"] + " " + dr["salary"] +
                        " " + dr["start"] + " " + dr["gender"] + " " + dr["PhoneNo"] +
                         dr["OfficeAddress"] + " " + dr["Department"] + " " + dr["BasicPay"] + " " + dr["Deductions"] +
                        " " + dr["TaxablePay"] + " " + dr["IncomeTax"] + " " + dr["NetPay"]); //.(1)(2)(3)(4)(5)(6)(7)(8));
                }
                con.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //public void Display()
        //{
        //    foreach (var item in PayrollList)
        //    {
        //        Console.WriteLine("\n name \t salary \t \t start \t gender");

        //        Console.WriteLine(item.name + "\t" + item.salary + "\t" + item.start + "\t" + item.gender);
        //    }
        //}
    }
}