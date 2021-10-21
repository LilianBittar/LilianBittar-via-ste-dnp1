using System;

namespace MathInSeparateNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Calculator();
            Console.WriteLine(c.Add(4,2));
            Console.WriteLine(c.Add(new int[] {4, 8, 1, 3}));
        }
    }
}