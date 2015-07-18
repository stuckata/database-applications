using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SoftUniDatabase
{
    public class EmployeeDao
    {

        public static void Add(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public static Employee FindByKey(int key)
        {
            using (var context = new SoftUniEntities())
            {
                return context.Employees.Find(key);
            }
        }

        public static void Modify(Employee employee, string newFirstName)
        {
            using (var context = new SoftUniEntities())
            {
                var currentEmployee = context.Employees.Find(employee.EmployeeID);
                currentEmployee.FirstName = newFirstName;
                context.SaveChanges();
            }         
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}
