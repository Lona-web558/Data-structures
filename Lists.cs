using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a new List of integers
        List<int> numbers = new List<int>();

        // Add elements to the List
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);

        // Add multiple elements at once
        numbers.AddRange(new int[] { 4, 5, 6 });

        // Print the List
        Console.WriteLine("List elements:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        // Access elements by index
        Console.WriteLine($"\nElement at index 2: {numbers[2]}");

        // Modify an element
        numbers[1] = 10;
        Console.WriteLine($"Modified element at index 1: {numbers[1]}");

        // Remove an element
        numbers.Remove(3);

        // Remove element at specific index
        numbers.RemoveAt(0);

        // Check if an element exists
        bool contains5 = numbers.Contains(5);
        Console.WriteLine($"\nDoes the list contain 5? {contains5}");

        // Get the count of elements
        Console.WriteLine($"Number of elements: {numbers.Count}");

        // Clear all elements
        numbers.Clear();
        Console.WriteLine($"Number of elements after clearing: {numbers.Count}");

        // Create a List with initial capacity
        List<string> fruits = new List<string>(5) { "Apple", "Banana", "Orange" };

        // Insert an element at a specific index
        fruits.Insert(1, "Mango");

        Console.WriteLine("\nFruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Find the index of an element
        int indexOfOrange = fruits.IndexOf("Orange");
        Console.WriteLine($"\nIndex of Orange: {indexOfOrange}");
    }
}