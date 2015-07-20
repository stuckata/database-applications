using System;
using _01_SoftUniDatabase;
using System.Linq;

namespace _01_SoftUniDatabaseTests
{
    public class DatabaseSearchQueries
    {
        public static void FindProjectsInTimePeriod()
        {
            var context = new SoftUniEntities();
            DateTime startDate = new DateTime(2001, 1, 1);
            DateTime endDate = new DateTime(2003, 1, 1);

            var projects =
                from employee in context.Employees
                join project in context.Projects
                on employee.EmployeeID equals project.ProjectID
                where project.StartDate >= startDate || project.EndDate <= endDate
                select new
                {
                    project.Name,
                    project.StartDate,
                    project.EndDate,
                    manager = employee.FirstName + " " + employee.LastName
                };

            foreach (var p in projects)
            {
                Console.WriteLine("PROJECT: {0} *** {1} - {2} *** MANAGER: {3}", p.Name, p.StartDate, p.EndDate, p.manager);
            }
        }

        public static void FindAddressesByCriteria()
        {
            var context = new SoftUniEntities();

            var addresses =
                (from a in context.Addresses
                 join t in context.Towns
                 on a.AddressID equals t.TownID
                 orderby a.Employees.Count()
                 select new
                {
                    address = a.AddressText,
                    town = t.Name,
                    employeesCount = a.Employees.Count()
                }).Take(10);

            foreach (var a in addresses)
            {
                Console.WriteLine("ADDRESS: {0}, TOWN: {1}, NUMBER OF EMPLOYEES: {2}", a.address, a.town, a.employeesCount);
            }
        }

        public static void FindEmployeesByCriteria()
        {

        }

        public static void FindDepartmentsWithMoreThanFiveEmployees()
        {
          
        }
    }
}
