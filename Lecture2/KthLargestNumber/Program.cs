using System;

namespace KthLargestNumber
{
    class Program
    {
        static int Largest(int[] ints, int k){
            if(k > ints.Length) throw new Exception("K is larger than the length of the array");
            for(int i = 0; i < ints.Length -1; i++){
                for(int j = 0; j < ints.Length -1 -i; j++) if(ints[j] > ints[j + 1]){
                    int temp = ints[j + 1];
                    ints[j + 1] = ints[j];
                    ints[j] = temp;
                }
            }
            return ints[ints.Length - k];
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Largest(new int[] {6, 3, 5, 9,1, 2}, 1));
        }
    }
}