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
                group a.AddressID by new { addressText = a.AddressText, townName = a.Town.Name, employeesCount = a.Employees.Count() }
                into ad
                orderby ad.Key.employeesCount descending
                select new
                {
                   address = ad.Key.addressText,
                   town = ad.Key.townName,
                   empCount = ad.Key.employeesCount
                }).Take(10);

            foreach (var a in addresses)
            {
                Console.WriteLine("ADDRESS: {0}, TOWN: {1}, NUMBER OF EMPLOYEES: {2}", a.address, a.town, a.empCount);
            }
        }

        public static void FindEmployeesByCriteria()
        {
            var context = new SoftUniEntities();

            var employees =
                from e in context.Employees
                select new
                {
                    name = e.FirstName + " " + e.LastName,
                    job = e.JobTitle,
                    projects = e.Projects.OrderBy(p => p.Name)
                };

            foreach (var e in employees)
            {
                Console.WriteLine("NAME: {0} JOB: {1}", e.name, e.job);
                Console.WriteLine("PROJECTS:");
                Console.WriteLine("=====================================");
                foreach (var p in e.projects)
                {
                    Console.WriteLine("PROJECT NAME: {0}", p.Name);
                }
                Console.WriteLine("=====================================");
            }
        }

        public static void FindDepartmentsWithMoreThanFiveEmployees()
        {
          
        }
    }
}
