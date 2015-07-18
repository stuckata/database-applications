using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_SoftUniDatabase;

namespace _01_SoftUniDatabaseTests
{
    [TestClass]
    public class EmployeeDaoTest
    {
        private Employee employee;

        [TestMethod]
        public void Add()
        {
            var gandolf = new Employee()
            {
                FirstName = "Gandolf",
                LastName = "Thegray",
                JobTitle = "Network Administrator",
                DepartmentID = 11,
                HireDate = new DateTime(2001, 03, 27),
                Salary = 32500
            };

            EmployeeDao.Add(gandolf);
            this.employee = gandolf;

            Assert.IsNotNull(gandolf.EmployeeID);
        }

        [TestMethod]
        public void FindByKey()
        {
            Add();

            int key = this.employee.EmployeeID;
            Employee found = EmployeeDao.FindByKey(key);

            Assert.IsTrue(key == found.EmployeeID);
        }

        [TestMethod]
        public void Modify()
        {
            Add();

            String name = "ModifiedName";
            this.employee.FirstName = name;
            int key = this.employee.EmployeeID;
            EmployeeDao.Modify(this.employee);
            Employee found = EmployeeDao.FindByKey(key);

            Assert.AreEqual(name, found.FirstName);
        }

        [TestMethod]
        public void Delete()
        {
            Add();

            int key = this.employee.EmployeeID;
            EmployeeDao.Delete(this.employee);

            Employee found = EmployeeDao.FindByKey(key);
            Assert.IsNull(found);
        }
    }
}
