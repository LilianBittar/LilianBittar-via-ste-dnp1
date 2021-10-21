using System;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var ptemp1 = new PartTimeEmployee("Employee1", 120, 40);
            var ptemp2 = new FullTimeEmployee("Employee2", 1100);
            var ptemp3 = new PartTimeEmployee("Employee2", 140, 10);
            var ptemp4 = new FullTimeEmployee("Employee2", 1200);
            var ptemp5 = new FullTimeEmployee("Employee2", 1100);
            var com = new Company();
            com.HireNewEmployee(ptemp1);
            com.HireNewEmployee(ptemp2);
            com.HireNewEmployee(ptemp3);
            com.HireNewEmployee(ptemp4);
            com.HireNewEmployee(ptemp5);
            Console.WriteLine(com.GetMonthlySalaryTotal());
        }
    }
}