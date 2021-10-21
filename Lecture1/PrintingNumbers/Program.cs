using System;

namespace PrintingNumbers
{
    class Program {

        static void PrintEven(int x) {
            for (int i = 0; i < x; i++) {
                if (i % 2 == 0) {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }

        static void PrintOdd(int x) {
            for (int i = 0; i < x; i++) {
                if (i % 2 != 0) {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
		
        static void PrintDivisible(int x, int y) {
            for (int i = 0; i < x; i++) {
                if (i % y == 0) {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args) {
            PrintEven(10);
            PrintOdd(10);
            PrintDivisible(7, 4);
        }
    }
}