using System;

namespace CarAndPredicates
{
     class Program
    {
        static void Main(string[] args)
        {
            List<Car> CarList = new List<Car>();

            CarList.Add(new Car("red", 3, 2, false));
            CarList.Add(new Car("yellow", 2, 4, true));
            CarList.Add(new Car("blue", 6, 7, false));
            CarList.Add(new Car("red", 3, 2, false));
            CarList.Add(new Car("black", 8, 9, true));

            Console.WriteLine("Red cars: ");
            CarList.FindAll(Car => Car.Color.Equals("red")).ForEach(Car => Console.WriteLine(Car.ToString()));

            Console.WriteLine("Red and Yellow cars: ");
            CarList.FindAll(Car => Car.Color.Equals("red") || Car.Color.Equals("yellow")).ForEach(Car => Console.WriteLine(Car.ToString()));

            string[] ArrayOfColors = new string[] {"red", "yellow", "black"};
            Console.WriteLine("Cars of colors of an array: ");
            CarList.FindAll(Car => {
                foreach(string color in ArrayOfColors) {
                    if (Car.Color.Equals(color)) return true;
                }
                return false;
            }).ForEach(Car => Console.WriteLine(Car.ToString()));

            int size = 2;
            Console.WriteLine("Car with engine size bigger than " + size + ":");
            CarList.FindAll(Car => Car.EngineSize > size).ForEach(Car => Console.WriteLine(Car.ToString()));
            
            int lower = 2;
            int higher = 4;
            Console.WriteLine("Car with engine size between " + lower + " and " + higher + ":");
            CarList.FindAll(Car => Car.EngineSize > lower && Car.EngineSize < higher).ForEach(Car => Console.WriteLine(Car.ToString()));

            int fuelEconomy = 4;
            Console.WriteLine("Car with a fuel economy lower than " + fuelEconomy + ":");
            CarList.FindAll(Car => Car.FuelEconomy < fuelEconomy).ForEach(Car => Console.WriteLine(Car.ToString()));

            int fuelEconomy2 = 7;
            Console.WriteLine("Car with a fuel economy lower than " + fuelEconomy + " and is manuale: ");
            CarList.FindAll(Car => Car.FuelEconomy < fuelEconomy).FindAll(Car => Car.IsManualShift).ForEach(Car => Console.WriteLine(Car.ToString()));
        }
    }
}