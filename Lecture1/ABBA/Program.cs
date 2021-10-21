using System;

namespace ABBA
{
    class Program {

        static string MakeABBA(string a, string b) {
            return $"{a}{b}{b}{a}";
        }

        static void Main(string[] args) {
            Console.WriteLine(MakeABBA("Hi", "Bye"));
            Console.WriteLine(MakeABBA("Yo", "Alice"));
            Console.WriteLine(MakeABBA("What", "Up"));
        }
    }
}