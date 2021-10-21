using System;

namespace Substring
{
    class Program {

        static string NTwice(string x, int n) {
            return $"{x.Substring(0, n)}{x.Substring(x.Length - n, n)}";
        }

        static void Main(string[] args) {
            Console.WriteLine(NTwice("Hello", 2));
            Console.WriteLine(NTwice("Chocolate", 3));
            Console.WriteLine(NTwice("Chocolate", 1));
        }
    }
}