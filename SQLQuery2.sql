# UC 1 

create database payroll_service;
use payroll_service;
select database();

# UC 2
create table employee_payroll  
(
id int not null AUTO_INCREMENT,
name varchar(30),
salary double not null,
primary key (id)
);