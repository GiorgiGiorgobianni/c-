using System;
using System.Collections;
using System.Collections.Generic;
using EmployeeNamespace;

namespace MainNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("John", "Doe", "123", 30, 50000, 4),
                new Employee("Jane", "Smith", "456", 25, 60000, 5),
                new Employee("Emily", "Jones", "789", 35, 45000, 3)
            };

            // Sorting by employee rating descending
            Console.WriteLine("Employees sorted by rating (descending):");
            employees.Sort(Employee.SortByRatingDescending());
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

            // Sorting by employee salary ascending
            Console.WriteLine("\nEmployees sorted by salary (ascending):");
            employees.Sort(Employee.SortBySalaryAscending());
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

            // Sorting by employee age ascending
            Console.WriteLine("\nEmployees sorted by age (ascending):");
            employees.Sort(Employee.SortByAgeAscending());
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.ReadLine();
        }
    }
}
