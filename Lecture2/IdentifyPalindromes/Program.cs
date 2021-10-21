using System;

namespace IdentifyPalindromes
{
    class Program
    {
        static bool IsPalindrome(string x){
            for(int i = 0; i < x.Length; i++) if(x[i] == ' ')x = x.Remove(i,1);
            for(int i = 0; i < x.Length/2; i++) if(x[i] != x[x.Length - i -1]) return false;
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome("mr owl ate my metal worm"));
        }
    }
}