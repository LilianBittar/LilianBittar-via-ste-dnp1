using System.Collections.Generic;

namespace Polymorphism
{
    class Company
    {
        private List<Employee> Employees;

        public Company() {

            Employees = new List<Employee>();

        }
        public double GetMonthlySalaryTotal(){
            double sum = 0;
            foreach (Employee e in Employees){
                sum += e.GetMonthlySalary();
            }
            return sum;
        }
        public void HireNewEmployee(Employee emp){
            Employees.Add(emp);
        }
    }
}