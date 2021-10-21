using System;

namespace BiggestDifference {
    class Program {

        static int BigDiff(int[] arr) {
            int minSoFar = arr[0];
            int maxSoFar = arr[0];
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < minSoFar) minSoFar = arr[i];
                if (arr[i] > maxSoFar) maxSoFar = arr[i];
            }
            return maxSoFar - minSoFar;
        }

        static void Main(string[] args) {
            Console.WriteLine(BigDiff(new int[] {10, 3, 5, 6}));
            Console.WriteLine(BigDiff(new int[] {7, 2, 10, 9}));
            Console.WriteLine(BigDiff(new int[] {2, 10, 7, 2}));
        }
    }
}