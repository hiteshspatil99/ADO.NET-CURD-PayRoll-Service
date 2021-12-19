Use payroll_service

Create procedure AddPayRollService
(
@name varchar(250),
@salary float,
@start datetime,
@gender varchar(1),
@PhoneNo bigint,
@OfficeAddress varchar(200),
@Department varchar(200),
@BasicPay money,
@Deductions money,
@TaxablePay money,
@IncomeTax money,
@NetPay money,
@Dept_id int
)
as
begin try

Insert into employee_payroll Values (@name,@salary,@start,@gender,@PhoneNo,@OfficeAddress,@Department,@Deductions,@TaxablePay,@IncomeTax,@NetPay);
---All are @ = dynamic values

END TRY
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber, ---handling for error inbuilt method
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorMassage;
	
END CATCH
select * from employee_payroll

Create procedure GetPayrollServices	
(
 @id int
)
as
begin try
     
	 select * from employee_payroll
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch

Create procedure UpdatePayrollServices	
@name varchar(250),
@salary float,
@start datetime,
@gender varchar(1),
@PhoneNo bigint,
@OfficeAddress varchar(200),
@Department varchar(200),
@BasicPay money,
@Deductions money,
@TaxablePay money,
@IncomeTax money,
@NetPay money,
@Dept_id int
)
as
begin try
      UPDATE employee_payroll SET name=@name, salary= @salary ,start = @start, gender=@gender,PhoneNo= @PhoneNo,OfficeAddress=@OfficeAddress,Department=@Department,BasicPay=@BasicPay,Deductions=@Deductions,TaxablePay= @TaxablePay,IncomeTax=@IncomeTax,NetPay=@NetPay Where Dept_id= @Dept_id
	 
end try
Begin Catch
Select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch


 Create procedure DeletePayrollServices	
(
 @id int
)
as
begin try
     Delete from employee_payroll where id = @id
	 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch

select * from employee_payroll

exec DeletePayrollServices


