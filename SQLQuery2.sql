# UC 1 

create database payroll_service;

# UC 2
use payroll_service;
select database();

# UC 3
create table employee_payroll  
(
id int not null AUTO_INCREMENT,
name varchar(30),
salary double not null,
primary key (id)
);
# UC 4

INSERT into employee_payroll ( name salary, start) VALUES
('Bill',100000, '2018-01-03')
('Tarisa',100000, '2019-11-13')
('Charlei',100000, '2020-05-21');

#	UC 5

select * from employee_payroll WHERE name ='Bill';
select * from employee_payroll where start between CAST('2018-01-03' as date) and date(now());



