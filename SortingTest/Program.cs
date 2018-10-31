using System;
using System.Linq;
using Sorting;

namespace SortingTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();

            int[] numbers = CreateArray();
            int[] numbers1 = CreateArray();

            var expected = numbers.OrderBy(x => x).ToArray();

            var expected1 = numbers1.OrderBy(x => x).ToArray();

            numbers.QuickSort();
            numbers1.MergeSort();

            Console.WriteLine("Is correct QuickSort: {0}", numbers.SequenceEqual(expected));
            Console.WriteLine("Is correct MergeSort: {0}", numbers1.SequenceEqual(expected1));

            Console.ReadKey();

            int[] CreateArray()
            {
                var array = new int[1000000];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next();
                }

                return array;
            }
        }
    }
}
