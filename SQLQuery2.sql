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



# UC 6

alter table employee_payroll add gender char(1) after name;
update employee_payroll  set gender = 'f' where name = 'Tarisa';
update employee_payroll  set gender = 'm' where name = 'Bill' or name ='charlie';
update employee_payroll  set salary = 300000.00 where name ='Tarisa'

# UC7
select Gender, sum(Salary) as TotalSalary from employee_payroll group by gender;
select Gender, avg(Salary) as AverageSalary from employee_payroll group by Gender;
select Gender, min(Salary) as Minimum from employee_payroll group by Gender;
select Gender, max(Salary) as Maximum from employee_payroll group by Gender;
select Gender, count(*) as MaleorFemale from employee_payroll group by Gender;

# UC 8
Alter table employee_payroll add 
phone int(15),
address varchar(50) default 'us',
department varchar(20) default 'cs' not null ;