using System;
using System.Collections.Generic;
using System.Linq;

namespace Companies_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            int noOfEmployees = int.Parse(Console.ReadLine());
            List<Employee> listOfAllEmployees = new List<Employee>();

            for (int i = 0; i < noOfEmployees; i++)
            {
                Employee employee = new Employee();
                string[] input = Console.ReadLine().Split(" ");
                employee.FirstName = input[0];
                employee.SurName = input[1];
                employee.Age = int.Parse(input[2]);
                employee.Company = input[3];

                listOfAllEmployees.Add(employee);
            }

            SortedDictionary<string, List<Employee>> dictCompanyListsEmployees = new SortedDictionary<string, List<Employee>>();

            for (int i = 0; i < listOfAllEmployees.Count; i++)
            {
                //if this is first Employee of a company, a new List is created and the Employee is added:
                if (!dictCompanyListsEmployees.ContainsKey(listOfAllEmployees[i].Company))
                {
                    List<Employee> employeeToCompany = new List<Employee>();
                    employeeToCompany.Add(listOfAllEmployees[i]);
                    dictCompanyListsEmployees.Add(listOfAllEmployees[i].Company, employeeToCompany);
                }

                //if already there is such a company, the current Employee is added to the list of Employees
                else
                {
                    List<Employee> currentEmployers = dictCompanyListsEmployees[listOfAllEmployees[i].Company];
                    currentEmployers.Add(listOfAllEmployees[i]);
                    dictCompanyListsEmployees[listOfAllEmployees[i].Company] = currentEmployers;
                }

            }

            //calculating and transferring the average employees age to the relevant company

            SortedDictionary<string, int> dictCompanyAverageAges = new SortedDictionary<string, int>();

            foreach(var company in dictCompanyListsEmployees)
            {
                int averageAge = 0;
                int sum = 0;

                for (int i = 0; i < company.Value.Count; i++)
                {
                    sum += company.Value[i].Age;
                }

                averageAge = sum / company.Value.Count;


                dictCompanyAverageAges.Add(company.Key, averageAge);
                Console.WriteLine($"In Company: {company.Key} - the average age is {averageAge} years");
            }

        }
    }
}
