namespace Polymorphism
{
    class FullTimeEmployee : Employee {
        public double MonthlySalary;
        
        public FullTimeEmployee(string name, double MonthlySalary) : base (name)
        {
            this.MonthlySalary = MonthlySalary;
        }
        
        public override double GetMonthlySalary() {
            return MonthlySalary;
        }
    }
}