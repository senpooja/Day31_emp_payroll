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
# UC 3

INSERT into employee_payroll ( name salary, start) VALUES
('Bill',100000, '2018-01-03')
('Tarisa',100000, '2019-11-13')
('Charlei',100000, '2020-05-21');