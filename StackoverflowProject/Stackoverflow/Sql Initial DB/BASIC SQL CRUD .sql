create database TutorialSQL
use TutorialSQL

/*Create table*/
create table Employees(
Employee_ID int primary key identity(1,1),
Emp_Name varchar(max),
Emp_Designation varchar(max)
)

/*Seed Data in the table*/
insert into Employees values('Darko Gelevski ','IT Sector')

/*Insert Data in the table*/
insert into Employees values(
'C#','Developer', null, null, null),
('Java', 'Programmer'),
('PHP','Programemer')

/*Few Selectors from all to where */
select * from Employees
select Employee_ID from Employees
select Emp_Name from Employees
select emp_name , emp_Designation from Employees
select * from Employees where Employee_id = 3
select * from Employees where emp_name ='C#'

/*Add New Column in the table*/
alter table Employees add Country varchar(50)
alter table Employees add Gender varchar(10), Hobbies varchar(50)

/*Update Record in the table*/
update Employees set Country = 'Macedonia'  
update Employees set Gender = 'Male' , Hobbies ='Develoing Applications'
Update Employees set Country ='UK' where Employee_ID = 1
Update Employees set Country ='USA' where Employee_ID = 3
update Employees set Country ='China' where Emp_Name = 'c#'

/*Delete Record in the table*/
delete from employees where Employee_ID = 1 
delete from Employees where Emp_name = 'Java'

/*Delete Column in the table*/
alter table Employees drop column Hobbies  

/*Delete All record in the table*/
truncate table Employees

/*Delete Entire table*/
drop table Employees

