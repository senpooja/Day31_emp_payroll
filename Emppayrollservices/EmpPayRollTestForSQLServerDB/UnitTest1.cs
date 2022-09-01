using Employee_PayrollUsingSQL;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    EmployeeRepo repo = new EmployeeRepo();
        //    EmployeeModel employee = new EmployeeModel();
        //    employee.EmployeeName = "Mohan";
        //    employee.Department = "Tech1";
        //    employee.PhoneNumber = "63029";
        //    employee.Address = "02-Patna";
        //    employee.Gender = 'M';
        //    employee.salary = 13000;
        //    employee.BasicPay = 10000.00M;
        //    employee.Deductions = 1500.00;
        //    employee.StartDate = Convert.ToDateTime("2020-11-03");
        //    //Mock<EmployeeRepo> mockObj = new Mock<EmployeeRepo>();
        //    //mockObj.Setup(t=>t.AddEmployee(It.IsIn<EmployeeModel>)).return (true);
        //    var result = repo.AddEmployee(employee);
        //    Assert.IsTrue(result);
        //}
        [TestMethod]
        public void GetAllEmployeeShouldReturnListOfRecords()
        {
            EmployeeRepo repo = new EmployeeRepo();
            var result = repo.GetAllEmployee();
            Assert.IsTrue(result);
        }
        //UC-3 Update Salary of Terisa to 30000000

        [TestMethod]
        public void UpdateSalaryOfanEmployee()
        {
            EmployeeRepo repo = new EmployeeRepo();
            var result = repo.UpdateSalary();
            Assert.AreEqual(0, result);
        }
        [TestMethod()]
        public void DateRangeSearch()
        {
            EmployeeRepo repo = new EmployeeRepo();
            var result = repo.DateRangeSearch();
            Assert.IsTrue(result);
        }

    }
}