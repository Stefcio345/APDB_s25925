using System;

namespace projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(ReturnMax([1,2,3,4,5]));

        }
        
        public static double CalculateAverage(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }

<<<<<<< HEAD
            double zmienna_suma = 0;
            foreach (int num in array)
            {
                zmienna_suma += num;
            }

            return zmienna_suma / array.Length;
=======
            double SUMA = 0;
            foreach (int num in array)
            {
                SUMA += num;
            }

            return SUMA / array.Length;
>>>>>>> feature-new
        }
        
        public static double ReturnMax(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }

            int max = array[0];
            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }
    }
}