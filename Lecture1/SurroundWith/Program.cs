using System;

namespace SurroundWith
{
    class Program {

        static string MakeOutWord(string outer, string inner) {
            return $"{outer.Substring(0, outer.Length / 2)}{inner}{outer.Substring(outer.Length / 2, outer.Length / 2)}";
        }

        static void Main(string[] args) {
            Console.WriteLine(MakeOutWord("<<>>", "Yay"));
            Console.WriteLine(MakeOutWord("<<>>", "WooHoo"));
            Console.WriteLine(MakeOutWord("[[]]", "word"));
        }
    }
}