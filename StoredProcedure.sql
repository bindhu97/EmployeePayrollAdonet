create Procedure spGetEmp(@Name varchar(100),@Salary bigint,@Gender varchar(2),@Address varchar(max),@PhoneNumber bigint,@Department varchar(100),@BasicPay Int,@Deductions Int,@TaxablePay Int,@IncomeTax Int,@NetPay Int)
As begin
try
select @Name,@Salary,@Gender,@Address,@PhoneNumber,@Department,@BasicPay,@Deductions,@TaxablePay,@IncomeTax,@NetPay from EmpPayrollTable Where ID=@ID
End try
Begin Catch
SELECT
		ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage
END CATCH


Exec spGetEmp

Create Procedure spUpdateEmployeeInfo(@Name varchar(Max),@Address varchar(max),@PhoneNumber bigint)
As begin
try
Update EmployeePayrollTable set PhoneNumber=@Phonenumber,Address=@Address where Name=@Name
End try
Begin Catch
SELECT
		ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage
END CATCH

Create Procedure EmployeePayrollTable(@Name varchar(100),@Salary bigint,@Gender varchar(2),@Address varchar(max),@PhoneNumber bigint,@Department varchar(100),@BasicPay Int,@Deductions Int,@TaxablePay Int,@IncomeTax Int,@NetPay Int)
As begin
try
insert into EmployeePayrollTable values(@Name,@Salary,@Gender,@Address,@PhoneNumber,@Department,@BasicPay,@Deductions,@TaxablePay,@IncomeTax,@NetPay)
End try
Begin Catch
SELECT
		ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage
END CATCH

Exec spAddEmployee

Create Procedure spDeleteEmployee(@Name varchar(max))
As begin
try
Delete from EmployeePayrollTable where Name=@Name
End try
Begin Catch
SELECT
		ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage
END CATCH

Exec spDeleteEmployee