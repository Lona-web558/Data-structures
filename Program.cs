using System;

class Program
{
    static void Main(string[] args)
    {
        // Declare and initialize an array
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

        // Access and print array elements
        Console.WriteLine("Array elements:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"Element at index {i}: {numbers[i]}");
        }

        // Modify an array element
        numbers[2] = 10;
        Console.WriteLine($"\nModified element at index 2: {numbers[2]}");

        // Another way to declare and initialize an array
        string[] fruits = { "Apple", "Banana", "Orange" };

        // Using foreach to iterate through the array
        Console.WriteLine("\nFruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Multi-dimensional array
        int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        // Access and print multi-dimensional array elements
        Console.WriteLine("\nMatrix elements:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
