using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var employee = context.Employees.Find(key);
                return employee;
            }
        }

        public static void Modify(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Attach(employee);
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }         
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Attach(employee);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}
