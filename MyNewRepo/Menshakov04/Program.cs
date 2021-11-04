using System;

namespace Menshakov04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var size = Convert.ToInt32(CheckInput());
            var array = GenerateArray(size);
            var arrays = FindEvenOddArrays(array);
            var firstLetterArray = ReplaceNumbersWithLetters(arrays.Item1);
            var secondLetterArray = ReplaceNumbersWithLetters(arrays.Item2);

            if (CountUpperLetters(firstLetterArray) > CountUpperLetters(secondLetterArray))
            {
                Console.WriteLine("First array contains more uppercase letter than second");
            }
            else
            {
                Console.WriteLine("Second array contains more uppercase letter than first");
            }

            Console.WriteLine($"First array: {string.Join(" ", firstLetterArray)}");
            Console.WriteLine($"Second array: {string.Join(" ", secondLetterArray)}");
        }

        public static uint CheckInput()
        {
            uint number = 0;
            Console.WriteLine("Enter number of elements in array: ");
            var parsingResult = uint.TryParse(Console.ReadLine(), out number);
            while (!parsingResult)
            {
                Console.WriteLine("You've entered not a number. Try again!");
                parsingResult = uint.TryParse(Console.ReadLine(), out number);
            }

            while (number < 2)
            {
                Console.WriteLine("Array size must be 2 or more. Try again!");
                uint.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static int[] GenerateArray(int size)
        {
            var random = new Random();
            var array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 27);
            }

            return array;
        }

        public static (int[], int[]) FindEvenOddArrays(int[] array)
        {
            var evenSize = 0;
            var oddSize = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenSize++;
                }
                else
                {
                    oddSize++;
                }
            }

            var evenArray = new int[evenSize];
            var oddArray = new int[oddSize];
            for (int i = 0, j = 0, k = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenArray[j++] = array[i];
                }
                else
                {
                    oddArray[k++] = array[i];
                }
            }

            return (evenArray, oddArray);
        }

        public static char[] ReplaceNumbersWithLetters(int[] array)
        {
            char[] lettersInUpper = { 'a', 'e', 'i', 'd', 'h', 'j' };
            var lettersArray = new char[array.Length];
            for (int i = 0; i < lettersArray.Length; i++)
            {
                char symbol = Convert.ToChar(array[i] + 'a' - 1);
                if (Array.IndexOf(lettersInUpper, symbol) != -1)
                {
                    symbol = char.ToUpper(symbol);
                }

                lettersArray[i] = symbol;
            }

            return lettersArray;
        }

        public static int CountUpperLetters(char[] array)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (char.IsUpper(array[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}