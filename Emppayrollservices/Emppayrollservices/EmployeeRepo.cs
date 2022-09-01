using Emppayrollservices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_PayrollUsingSQL
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollService;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //"Data Source=(localdb)\ProjectsV13;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from Employee_Payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = Convert.ToInt32(dr["id"]);
                            employeeModel.EmployeeName = Convert.ToString(dr["name"]);
                            Console.WriteLine(employeeModel.EmployeeID + " " + employeeModel.EmployeeName);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }

        //UC-3 Update salary of an Employee

        public int UpdateSalary()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"update employee_payroll set salary=30000000 where name='terisa';";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.RecordsAffected != 0)
                    {
                        return 0;
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                this.connection.Close();
            }
        }

        //UC-4 Date Range Search of employees

        public bool DateRangeSearch()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select name from Employee_Payroll where start_date between '2019-01-01' and GETDATE();";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // employeeModel.EmployeeID = (int)dr["id"];
                            employeeModel.EmployeeName = Convert.ToString(dr["name"]);
                            Console.WriteLine(employeeModel.EmployeeName);
                            Console.WriteLine("\n");
                        }
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployee_Details", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@Salary", model.Salary);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

    }
}