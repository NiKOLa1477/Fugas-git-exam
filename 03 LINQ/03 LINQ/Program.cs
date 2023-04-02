using System;

namespace LINQ
{
    internal class Program
    {      
        static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.Write($"{item}, ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Task1. Three parts of LINQ Query
            //1. Init and print data source
            Random rand = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(-10, 10); 
            Console.WriteLine("Generated array");
            PrintCollection<int>(array);
            //2. Query creation
            var positive = array.Where(i => i >= 0);
            //3. Query execution
            Console.WriteLine("Positive values");
            PrintCollection<int>(positive);
            Console.WriteLine();

            //Task2. Find values square of which is less than 20
            var squareLess20 = array.Where(i => i * i < 20);
            Console.WriteLine("Values square of which is less than 20");
            PrintCollection<int>(squareLess20);
            Console.WriteLine();

            //Task3. Find words which starts and ends with character
            string[] words = { "Shepard", "Jack", "Garrus", "Wrex", "Tali", "Liara", "Javik", "James" };
            Console.WriteLine("Words:");
            PrintCollection<string>(words);
            var StartAndEnds = words.Where(i => i.StartsWith('J') && i.EndsWith("k"));
            Console.WriteLine("Words which starts with J and ends with k");
            PrintCollection<string>(StartAndEnds);
            Console.WriteLine();

            //Task4. Find words which length is less than value
            var LengthLess5 = words.Where(i => i.Length < 5);
            Console.WriteLine("Words which length is less than 5");
            PrintCollection<string>(LengthLess5);
            Console.WriteLine();

            //Task5. Find values that less then next ones            
            var LessThanNext = array.Where((curr, i) => i < (array.Length - 1) ? curr < array[i + 1] : false);
            Console.WriteLine("Values that less then next ones");
            PrintCollection<int>(LessThanNext);
        }
    }
}