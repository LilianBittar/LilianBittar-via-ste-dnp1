using System;

namespace SpellOutTheNumber
{
    class Program
    {
        static string SpellOutNumber(long x){
        
            if(x == 0 ) return "zero";

            string[] numbers = {"", "one", "two", "three", "four", "five", "sex", "seven", "eight", "nine"};
            string[] socrats = {"", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "ninteen"};
            string[] decimals = {"", "ten", "twenty", "thirty", "fourty", "fifty", "sexty","seventy", "eighty", "ninety"};
            string[] order = {"thousand", "million", "billion"};

            string toReturn = "";
            int dino = 0; 

         
            while (x != 0)
            {
                string temp = "";
                long lastDigit = x % 10;
        
                temp = numbers[x % 10] + " ";
                if ((x/=10) == 0) {
                    toReturn = temp + toReturn;
                    break;}

                if((x % 10) == 1){toReturn = socrats[lastDigit] + " " + toReturn;}
                else{toReturn = decimals[x % 10] +  " " + temp + toReturn;}
                if ((x/=10) == 0) break;
                toReturn = (numbers[x % 10] == "" ? "" : numbers[x % 10] + " hundred ") + toReturn;
                if((x/=10) == 0) break;
                toReturn = order[dino++] + " " + toReturn;
            }
            return toReturn;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SpellOutNumber(1114));
        }
    }
}