namespace MathInSeparateNamespace.MathLib
{
    public class MathLib
    {
        class Calculator{
            public int Add(int a, int b) {
                return a + b;
            }

            public int Add(int[] arr) {
                int sum = 0;
                foreach (int i in arr) {
                    sum += i;
                }
                return sum;
            }
        }
    }
}