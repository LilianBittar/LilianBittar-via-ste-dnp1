using System;

namespace SumsAndQuestionMarks
{
    class Program
    {
        static string GenerateRandomString(){
            string toReturn = "";
            for(int i = 0; i < 20; i++)
            {
                int random = new Random().Next(48,91);
                if (random < 65 && random > 57)
                {
                    toReturn += "?";
                }
                else if (random > 64 && random < 91)
                {
                    toReturn += (char) (random + 32);
                }
                else if (random < 58 && random > 47)
                {
                    toReturn += (char) random;
                }
            }
            return toReturn;
        }

        static int FindSums(string s){
            int sum = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (47 < s[i] && s[i] < 58)
                {
                    sum += s[i] - 48;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateRandomString());
            Console.WriteLine(FindSums("jkl23?d1kj3?qer?k3n"));
        }
    }
}