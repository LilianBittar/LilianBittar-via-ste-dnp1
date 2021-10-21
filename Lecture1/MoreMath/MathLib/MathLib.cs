using System;

namespace MoreMath.MathLib
{
    class Calculator{
        public int Add(int a, int b) {
            return a + b;
        }

        public int Add(int[] arr) {
            int sum = 0;
            foreach (int i in arr) {
                sum += i;
            }
            return sum;
        }
        public void Maximum() {
            Console.Write("a= ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b= ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Maximum: " + (a > b ? a : b));
        }
    }
}