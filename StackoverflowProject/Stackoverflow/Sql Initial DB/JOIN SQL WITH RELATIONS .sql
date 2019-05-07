use TutorialSQL
go

/*Main Table Car*/
Create table Car(car_id int primary key identity(1,1),car_name varchar(50))
insert into car values('BMW'),('AUDI'),('Ferrari')
select * from Car

/*Another Registstation Table with key from CAR */
Create table registration(r_ID int primary key identity(1,1), Registration# varchar(50), car_Reg_ID int foreign key references Car(Car_ID))
insert into registration values('AUK-255', 1)
select * from registration 

--JOINS
Select Registration.r_ID, registration.Registration#,Car.car_name 
from registration inner join Car on registration.car_Reg_ID=car.car_id

Select Registration.r_ID, registration.Registration#,Car.car_name 
from registration left join Car on registration.car_Reg_ID=car.car_id

Select Registration.r_ID, registration.Registration#,Car.car_name 
from registration right join Car on registration.car_Reg_ID=car.car_id

Select Registration.r_ID, registration.Registration#,Car.car_name 
from registration full join Car on registration.car_Reg_ID=car.car_id

create table Country(Country_ID int primary key identity(1,1), Country_Name varchar(max)) 
create table Province(Prov_ID int primary key identity(1,1), Province_Name varchar(max), CountryID int foreign key references Country(Country_ID))
create table City(City_ID int primary key identity(1,1), City_Name varchar(max),ProvinceID int foreign key references Province(Prov_ID))

create table Student_Bio(Student_Id int primary key identity(1,1),
 Student_Name varchar(50), 
 Student_Roll# varchar(50),
 Contry_Id int foreign key references Country(Country_ID),
 Province_ID int foreign key references Province(Prov_ID),
 City_ID int foreign key references City(City_ID))

 insert into Country values('UK')
 insert into Province values('England', 2)
 insert into City values('London', 2)
 insert into Student_Bio values('DarkoBritaneco', 'Kecac', 2, 2, 2)

 select * from Country
 select * from Province
 select * from City 
 select * from Student_Bio
 -- Hard core join
 select Student_Bio.Student_Id, Student_Bio.Student_Name, Student_Bio.Student_Roll#, Country.Country_Name, Province.Province_Name, City.City_Name 
 from Student_Bio
 inner join Country on Student_Bio.Contry_Id = Country.Country_ID 
 inner join Province on Student_Bio.Province_ID = Province.Prov_ID
 inner join City on Student_Bio.City_ID = City.City_ID

 --drop table city