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

        public static void FindAdressesByCriteria()
        {
            
        }

        public static void FindEmployeesByCriteria()
        {

        }

        public static void FindDepartmentsWithMoreThanFiveEmployees()
        {
          
        }
    }
}
