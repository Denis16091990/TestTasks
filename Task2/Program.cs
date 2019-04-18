using static System.Console;

namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Task2.Utils;

    internal class Program
    {
        /// <summary>
        ///     Check for duplicates in array
        /// </summary>
        /// <param name="intArray"></param>
        private static void CheckForDuplicates(int[] intArray)
        {
            // Find duplicates
            if (intArray.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .Any())
            {
                throw new Exception("There are duplicates in result array found");
            }
        }

        /// <summary>
        ///     Generate array with unique numbers 1 - 100 000 and reorder using Fisher–Yates shuffle
        /// </summary>
        /// <returns></returns>
        private static int[] GenerateRandomIntArray()
        {
            var random = new Random(); // init randomizer

            // Get int range
            var intArray = Enumerable.Range(1, 100000).ToArray();

            // Fisher–Yates shuffle
            for (var i = 1; i <= intArray.Length - 1; i++)
            {
                var swapIndex = random.Next(i + 1);
                var tmp = intArray[swapIndex];
                intArray[swapIndex] = intArray[i];
                intArray[i] = tmp;
            }

            return intArray;
        }

        /// <summary>
        ///     Generate array with unique numbers 1 - 100 000 and reorder using order by Random
        /// </summary>
        /// <returns></returns>
        private static int[] GenerateRandomIntArray2()
        {
            var random = new Random(); // init randomizer

            // Get int range, order by random,
            return Enumerable.Range(1, 100000)
                .OrderBy(x => random.Next())
                .ToArray();
        }

        /// <summary>
        ///     Generate array with unique numbers 1 - 100 000 and reorder using Fisher–Yates shuffle and Lazy Yield return
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<int> GenerateRandomIntArray3()
        {
            var random = new Random(); // init randomizer

            // Get int range
            var intArray = Enumerable.Range(1, 100000).ToArray();

            // Fisher–Yates shuffle
            for (var i = intArray.Length - 1; i > 1; i--)
            {
                var swapIndex = random.Next(i + 1);
                yield return intArray[swapIndex];
                intArray[swapIndex] = intArray[i];
            }

            yield return intArray[0];
        }

        private static void Main(string[] args)
        {
            int[] intArray;
            using (new ElapsedTimeLogger("Creating random int array Fisher–Yates shuffle "))
            {
                intArray = GenerateRandomIntArray();
            }

            CheckForDuplicates(intArray);

            int[] intArray2;
            using (new ElapsedTimeLogger("Creating random int array order by Random"))
            {
                intArray2 = GenerateRandomIntArray2();
            }

            CheckForDuplicates(intArray2);

            int[] intArray3;
            using (new ElapsedTimeLogger("Creating random int array Fisher–Yates shuffle and Lazy Yield return"))
            {
                intArray3 = GenerateRandomIntArray3().ToArray();
            }

            CheckForDuplicates(intArray3);

            WriteLine("Press any key to continue");
            ReadKey();
        }
    }
}