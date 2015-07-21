using _01_SoftUniDatabaseTests;
using System;

namespace _01_SoftUniDatabase
{
    class Program
    {
        static void Main()
        {
            //for EmployeeDao please look at folder 02_EmployeeDaoClass

            //03_DatabaseSearchQueries
            DatabaseSearchQueries.FindProjectsInTimePeriod();
            Console.WriteLine();
            Console.WriteLine("======================================================================");
            Console.WriteLine();
            DatabaseSearchQueries.FindAddressesByCriteria();
            Console.WriteLine();
            Console.WriteLine("======================================================================");
            Console.WriteLine();
            DatabaseSearchQueries.FindEmployeesByCriteria();
            Console.WriteLine();
            Console.WriteLine("======================================================================");
            Console.WriteLine();
            DatabaseSearchQueries.FindDepartmentsWithMoreThanFiveEmployees();
        }
    }
}
