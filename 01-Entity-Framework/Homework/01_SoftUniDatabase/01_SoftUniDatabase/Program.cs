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
            var context = new SoftUniEntities();
            var employees = context.Employees;
        }
    }
}
