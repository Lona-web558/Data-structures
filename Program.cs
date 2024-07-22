using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a new Stack of integers
        Stack<int> stack = new Stack<int>();

        // Push elements onto the stack
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Print the stack
        Console.WriteLine("Stack elements:");
        foreach (int item in stack)
        {
            Console.WriteLine(item);
        }

        // Peek at the top element without removing it
        Console.WriteLine($"\nTop element: {stack.Peek()}");

        // Pop an element from the stack
        int poppedItem = stack.Pop();
        Console.WriteLine($"Popped element: {poppedItem}");

        // Check if the stack contains a specific element
        bool contains2 = stack.Contains(2);
        Console.WriteLine($"\nDoes the stack contain 2? {contains2}");

        // Get the count of elements
        Console.WriteLine($"Number of elements: {stack.Count}");

        // Clear all elements
        stack.Clear();
        Console.WriteLine($"Number of elements after clearing: {stack.Count}");

        // Example: Using a stack to reverse a string
        string original = "Hello, World!";
        Stack<char> charStack = new Stack<char>();

        // Push each character onto the stack
        foreach (char c in original)
        {
            charStack.Push(c);
        }

        // Pop characters from the stack to reverse the string
        string reversed = new string(charStack.ToArray());
        Console.WriteLine($"\nOriginal string: {original}");
        Console.WriteLine($"Reversed string: {reversed}");

        // Example: Check for balanced parentheses
        string expression = "((())())()";
        bool isBalanced = CheckBalancedParentheses(expression);
        Console.WriteLine($"\nExpression: {expression}");
        Console.WriteLine($"Is balanced? {isBalanced}");
    }

    static bool CheckBalancedParentheses(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                stack.Pop();
            }
        }

        return stack.Count == 0;
    }
}