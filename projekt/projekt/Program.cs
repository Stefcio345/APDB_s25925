using System;

namespace projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(CalculateAverage([1,2,3,4,5]));

        }
        
        public static double CalculateAverage(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }

            double sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }

            return sum / array.Length;
        }
        
        
    }
}