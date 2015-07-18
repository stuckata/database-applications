using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SoftUniDatabase
{
    class Program
    {
        static void Main()
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

            var currentEmployee = EmployeeDao.FindByKey(301);
            Console.WriteLine(currentEmployee.FirstName);

            gandolf.FirstName = "Gandalf";
            EmployeeDao.Modify(gandolf);
            Console.WriteLine(gandolf.FirstName);

            var currentEmployee = EmployeeDao.FindByKey(301);
            EmployeeDao.Delete(currentEmployee);
        }
    }
}
