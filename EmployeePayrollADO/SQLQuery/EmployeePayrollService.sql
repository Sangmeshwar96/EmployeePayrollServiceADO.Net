--Creating database Employee_Payroll_Service
create database Employee_Payroll_Service;

--Using Employee_Payroll_Service
use Employee_Payroll_Service;

--Craeting table in DataBase
Create Table Employee (
EmpId int identity (1,1) primary key,
Name varchar(20),
Gender varchar(1),
Phone varchar(12),
Address varchar(20),
Department varchar(20),
Salary int,
Startdate Datetime,
);
Select * from Employee;

insert into Employee values
('Bill',100000.00,'2018-01-03'),
('Terissa',200000.00,'2019-11-13'),
('Charlie',300000.00,'2020-05-21');