using System;

namespace ArrayClumps
{
    class Program {

        static int CountClumps(int[] arr) {
            int clumps = 0;
            bool inClump = false;
            int i = 1;
            while (i < arr.Length) {
                if (arr[i - 1] == arr[i]) {
                    if (!inClump) {
                        inClump = true;
                        clumps++;
                    }
                } else {
                    inClump = false;
                }
                i++;                
            }
            return clumps;
        }

        static void Main(string[] args) {
            Console.WriteLine(CountClumps(new int[] {1, 2, 2, 3, 4, 4}));
            Console.WriteLine(CountClumps(new int[] {1, 1, 2, 1, 1}));
            Console.WriteLine(CountClumps(new int[] {1, 1, 1, 1, 1}));
        }
    }
}