--UC1 Create Database
Create Database EmployeePayroll;
use EmployeePayroll;

--UC2 Create table

Create Table EmployeePayrollTable(ID bigint Identity(1,1)Primary Key, Name varchar(100), Salary bigint, Start date)

--UC3 Insert Data in Employee_Payroll table

Insert into EmployeePayrollTable values ('Alex', 25000, '2020-02-05'), ('Sunil', 30000, '2018-01-01'), ('Meena', 35000, '2019-05-05'), ('Asha', 40000, '2018-08-04');

--UC4 to view table

select * from EmployeePayrollTable

--UC5 To view details of a particular Employee by name or between dates

Insert into EmployeePayrollTable values ('Bill', 50000, '2018-01-01'), ('Austin', 10000, '2019-09-09'), ('Richu', 34000, '2020-04-04');

select * from EmployeePayrollTable where Name = 'Bill'
select * from EmployeePayrollTable where Start between cast ('2018-01-01' as date) and Getdate()

--UC6 Add Gender column and update gender in EmployeeRollTable

alter table EmployeePayrollTable add Gender varchar(10) 
update EmployeePayrollTable set Gender = 'M' where Name = 'Alex' or Name = 'Bill' or Name = 'Austin' or Name = 'Sunil'
update EmployeePayrollTable set Gender = 'F' where Name = 'Meena' or Name = 'Asha' or Name = 'Richu'

--UC7 Using Aggregate Function

select Sum(Salary) as Total_Salary_Of_Male from EmployeePayrollTable where Gender = 'M' GROUP BY Gender
select Sum(Salary) as Total_Salary_Of_Female from EmployeePayrollTable where Gender = 'F' GROUP BY Gender
select Sum(Salary) as Total_Salary_Of_Employees from EmployeePayrollTable

select Avg(Salary) as Average_Salary_Of_Male from EmployeePayrollTable where Gender = 'M' GROUP BY Gender
select Avg(Salary) as Average_Salary_Of_Female from EmployeePayrollTable where Gender = 'F' GROUP BY Gender
select Avg(Salary) as Average_Salary_Of_Employees from EmployeePayrollTable

select Min(Salary) as Minimum_Salary_Of_Male from EmployeePayrollTable where Gender = 'M' GROUP BY Gender
select Min(Salary) as Minimum_Salary_Of_Female from EmployeePayrollTable where Gender = 'F' GROUP BY Gender
select Min(Salary) as Minimum_Salary_Of_Employee from EmployeePayrollTable

select Max(Salary) as Maximum_Salary_Of_Male from EmployeePayrollTable where Gender = 'M' GROUP BY Gender
select Max(Salary) as Maximum_Salary_Of_Female from EmployeePayrollTable where Gender = 'F' GROUP BY Gender
select Max(Salary) as Maximum_Salary_Of_Employee from EmployeePayrollTable

select Count(Id) as Number_Of_Male_Employees from EmployeePayrollTable where Gender = 'M' GROUP BY Gender
select Count(Id) as Number_Of_Female_Employees from EmployeePayrollTable where Gender = 'F' GROUP BY Gender
select Count(Id) as Total_Employees from EmployeePayrollTable

--UC8 Extend EmployeePayrollTable Personal Data

alter table EmployeePayrollTable add PhoneNumber bigint,  Address varchar(100), Department varchar(50) not null default 'Test'
update EmployeePayrollTable set PhoneNumber = 123456789, Address = 'Bangalore', Department = 'HR' WHERE Name = 'Alex'
update EmployeePayrollTable set PhoneNumber = 234567891, Address = 'Mysore', Department = 'DEveloper' WHERE Name = 'Sunil'
update EmployeePayrollTable set PhoneNumber = 345678912, Address = 'Mangalore', Department = 'IT' WHERE Name = 'Meena'
update EmployeePayrollTable set PhoneNumber = 456789123, Address = 'Hubli', Department = 'DataBasing' WHERE Name = 'Asha'
update EmployeePayrollTable set PhoneNumber = 567891234, Address = 'Dharwad', Department = 'Desiger' WHERE Name = 'Bill'
update EmployeePayrollTable set PhoneNumber = 678912345, Address = 'Tumkur', Department = 'Manager' WHERE Name = 'Austin'
update EmployeePayrollTable set PhoneNumber = 789123456, Address = 'TamilNadu', Department = 'Analyst' WHERE Name = 'Richu'

--UC9 Extend EmployeePayrollTable to more columns

alter table EmployeePayrollTable add BasicPay bigint, Deductions bigint, TaxablePay bigint, IncomeTax bigint, NetPay bigint
update EmployeePayrollTable set BasicPay = 10000, Deductions = 2000, TaxablePay = 1000, IncomeTax = 1000, NetPay = 25000 where Name = 'Alex'
update EmployeePayrollTable set BasicPay = 10000, Deductions = 2000, TaxablePay = 1000, IncomeTax = 1500, NetPay = 30000 where Name = 'Sunil'
update EmployeePayrollTable set BasicPay = 10000, Deductions = 2200, TaxablePay = 1000, IncomeTax = 1800, NetPay = 35000 where Name = 'Meena'
update EmployeePayrollTable set BasicPay = 10000, Deductions = 2200, TaxablePay = 1500, IncomeTax = 1800, NetPay = 40000 where Name = 'Asha'
update EmployeePayrollTable set BasicPay = 10000, Deductions = 3000, TaxablePay = 2000, IncomeTax = 2000, NetPay = 50000 where Name = 'Bill'
update EmployeePayrollTable set BasicPay = 5000, Deductions = 500, TaxablePay = 300, IncomeTax = 250, NetPay = 10000 where Name = 'Austin'
update EmployeePayrollTable set BasicPay = 10000, Deductions = 2000, TaxablePay = 1000, IncomeTax = 1800, NetPay = 34000 where Name = 'Richu'

--UC10 Make Richu as part of sales & Marketing

insert into EmployeePayrollTable (Department, Name) values ('Sales & Marketing', 'Richu')

select * from EmployeePayrollTable where Name = 'Richu'

--UC11 Implements the ER Diagram into payroll service DB

create table EmployeePayrollTable1 (ID bigint Identity(1,1)Primary Key, EmpID bigint, Department varchar(45) NOT NULL, DepartmentId bigint, FOREIGN KEY (EmpID) REFERENCES EmployeePayrollTable(Id));
insert into EmployeePayrollTable1 (EmpId, Department) values ('1', 'Finance'),('2', 'Sales'), ('3', 'Marketing')
select * from EmployeePayrollTable1

alter table EmployeePayrollTable1 add Name varchar(10), Gender varchar (1), Salary bigint
delete from EmployeePayrollTable1 where ID = '9'
update EmployeePayrollTable1 set Name = 'Jimmy', DepartmentId = 12345, Gender = 'M', Salary = 20000 where Department = 'Finance'
update EmployeePayrollTable1 set Name = 'Satish', DepartmentId = 12346, Gender = 'M', Salary = 24000 where Department = 'Sales'
update EmployeePayrollTable1 set Name = 'Aurora', DepartmentId = 12347, Gender = 'F', Salary = 35000 where Department = 'Marketing'

select Sum(Salary) as Total_Salary_Of_Male from EmployeePayrollTable1 where Gender = 'M' GROUP BY Gender
select Sum(Salary) as Total_Salary_Of_Female from EmployeePayrollTable1 where Gender = 'F' GROUP BY Gender
select Sum(Salary) as Total_Salary_Of_Employees from EmployeePayrollTable1

select Avg(Salary) as Average_Salary_Of_Male from EmployeePayrollTable1 where Gender = 'M' GROUP BY Gender
select Avg(Salary) as Average_Salary_Of_Female from EmployeePayrollTable1 where Gender = 'F' GROUP BY Gender
select Avg(Salary) as Average_Salary_Of_Employees from EmployeePayrollTable1

select Min(Salary) as Minimum_Salary_Of_Male from EmployeePayrollTable1 where Gender = 'M' GROUP BY Gender
select Min(Salary) as Minimum_Salary_Of_Female from EmployeePayrollTable1 where Gender = 'F' GROUP BY Gender
select Min(Salary) as Minimum_Salary_Of_Employee from EmployeePayrollTable1

select Max(Salary) as Maximum_Salary_Of_Male from EmployeePayrollTable1 where Gender = 'M' GROUP BY Gender
select Max(Salary) as Maximum_Salary_Of_Female from EmployeePayrollTable1 where Gender = 'F' GROUP BY Gender
select Max(Salary) as Maximum_Salary_Of_Employee from EmployeePayrollTable1

select Count(Id) as Number_Of_Male_Employees from EmployeePayrollTable1 where Gender = 'M' GROUP BY Gender
select Count(Id) as Number_Of_Female_Employees from EmployeePayrollTable1 where Gender = 'F' GROUP BY Gender
select Count(Id) as Total_Employees from EmployeePayrollTable1

--UC12 Ensure All Retrieve Queries

alter table EmployeePayrollTable1 add Start date
Insert into EmployeePayrollTable1 (EmpId, Department,DepartmentId,Name,Gender,Salary,Start) values ('4','Analyst',12348,'Amaira','F',24000,'2018-01-01'),('5','Testing',12349,'Justin','M',19000,'2020-03-03'),('6','HR',12350,'Salena','F',40000,'2019-05-05')
delete from EmployeePayrollTable1 where ID = '10022'

select * from EmployeePayrollTable1 where Name = 'Justin'
select * from EmployeePayrollTable1 where Start between cast ('2018-01-01' as date) and Getdate()

select * from EmployeePayrollTable1
update EmployeePayrollTable1 set Start = '2017-08-09' where Name = 'Jimmy'
update EmployeePayrollTable1 set Start = '2019-08-19' where Name = 'Satish'
update EmployeePayrollTable1 set Start = '2017-10-09' where Name = 'Aurora'



