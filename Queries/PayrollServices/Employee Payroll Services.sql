--UC1 Created database
create database payroll_service;
USE payroll_service;



-- UC2reated Table

create Table employee_payroll(
id int identity (1,1)primary key,
name varchar(150) NOT NULL,
salary float NOT NULL,
start datetime NOT NULL,
);
 select * from employee_payroll
 


  --UC3 Inserted data

  insert into employee_payroll(
  name, salary, start) 
  VALUES
  ('Hitesh' , 100000.00, '2021-02-08'),
  ('Gitesh' , 80000.00, '2021-03-08'),
  ('Ritesh' , 70000.00, '2021-04-08'),
  ('Nitesh' , 60000.00, '2021-05-08');

 
 
 --UC4 Retrieved All data

  select * from employee_payroll
  
  

  --UC5 To find Data By parmeter & change by CAST

  select salary from employee_payroll
  where name = 'Hitesh'

  select * from employee_payroll
  where start between  CAST('2021-04-08'as date)and  GETDATE();

  
  
   
 --UC6 Adding Feild Gender & name

  Alter table employee_payroll add gender char(1);
  UPDATE employee_payroll SET gender = 'F' WHERE name='Gitesh' or name='Nitesh';
  UPDATE employee_payroll SET gender = 'M' WHERE name='Hitesh' or name='Ritesh';
  
  select * from employee_payroll 



  --UC7 To Find Sum,Avg,Min,Max & Count By gender wise

  SELECT SUM(salary) as MaleSalarySum From employee_payroll where gender = 'M' GROUP BY gender;
  SELECT SUM(salary) as FemaleSalarySum From employee_payroll where gender = 'F' GROUP BY gender;
  
  SELECT AVG(salary) as MaleSalarySum From employee_payroll where gender = 'M' GROUP BY gender;
  SELECT AVG(salary) as FemaleSalarySum From employee_payroll where gender = 'F' GROUP BY gender;

  SELECT MIN(salary) as MaleSalarySum From employee_payroll where gender = 'M' GROUP BY gender;
  SELECT MIN(salary) as FemaleSalarySum From employee_payroll where gender = 'F' GROUP BY gender;
  
  SELECT MAX(salary) as MaleSalarySum From employee_payroll where gender = 'M' GROUP BY gender;
  SELECT MAX(salary) as FemaleSalarySum From employee_payroll where gender = 'F' GROUP BY gender;

  SELECT COUNT(salary) as MaleCOUNT From employee_payroll where gender = 'M' GROUP BY gender;
  SELECT COUNT(salary) as FemaleCOUNT From employee_payroll where gender = 'F' GROUP BY gender;

  select * from employee_payroll
  
  


  --UC8 TO Add ColumnS & Set Respective Data
  Alter table employee_payroll add 
  PhoneNo int,
  OfficeAddress varchar(50) not null default 'Pune',
  Department varchar(50) Not null default 'Administrative';

  
  UPDATE employee_payroll SET officeAddress = 'Mumbai' WHERE name='Gitesh';

  

  --UC9 Added Columns
  select * from employee_payroll

 Alter table employee_payroll add 
  BasicPay money,
  Deductions money,
  TaxablePay money,
  IncomeTax money,
  NetPay money;

  


  --UC10 Inserted Data Again But two same Name has to different

  select * from employee_payroll
   UPDATE employee_payroll SET Department = 'Sales' WHERE id= 4;
   UPDATE employee_payroll SET Department = 'Marketing' WHERE id= 8;


   --UC11 create Table EmpDepartment & ER diagram
   USE payroll_service;
   create Table employee_Dept(
   Id int identity (1,1) primary key,
   Dept_Name varchar(20) not null,
   )
   select * from employee_Dept

   Alter table employee_payroll ADD Dept_id int foreign key references employee_Dept(Id);

   

  --UC12 Retriving All Quries done like UC4 ,UC5 & UC7 are working with New Table Sructure.

  insert into employee_Dept values('HR')
  insert into employee_Dept values('Sales')
  
