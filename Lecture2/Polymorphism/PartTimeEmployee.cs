namespace Polymorphism
{
    class PartTimeEmployee : Employee {
        public double HourlyWage;
        public int HoursPerMonth;
        
        public PartTimeEmployee(string name, double HourlyWage, int HoursPerMonth) : base (name)
        {
            this.HourlyWage = HourlyWage;
            this.HoursPerMonth = HoursPerMonth;
        }
        public override double GetMonthlySalary() {
            return HoursPerMonth * HourlyWage;
        }
    }
}