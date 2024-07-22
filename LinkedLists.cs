using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Using built-in LinkedList<T>
        Console.WriteLine("Built-in LinkedList<T> Example:");
        LinkedList<string> builtInList = new LinkedList<string>();

        // Add elements
        builtInList.AddLast("Apple");
        builtInList.AddLast("Banana");
        builtInList.AddFirst("Orange");

        // Print the list
        foreach (string fruit in builtInList)
        {
            Console.WriteLine(fruit);
        }

        // Remove an element
        builtInList.Remove("Banana");

        Console.WriteLine("\nAfter removing 'Banana':");
        foreach (string fruit in builtInList)
        {
            Console.WriteLine(fruit);
        }

        // Custom Linked List implementation
        Console.WriteLine("\nCustom Linked List Example:");
        CustomLinkedList<int> customList = new CustomLinkedList<int>();

        // Add elements
        customList.AddLast(1);
        customList.AddLast(2);
        customList.AddLast(3);

        // Print the list
        customList.PrintList();

        // Remove an element
        customList.Remove(2);

        Console.WriteLine("\nAfter removing 2:");
        customList.PrintList();

        // Add element at the beginning
        customList.AddFirst(0);

        Console.WriteLine("\nAfter adding 0 at the beginning:");
        customList.PrintList();
    }
}

// Custom implementation of a singly linked list
public class CustomLinkedList<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public void AddFirst(T data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
    }

    public void AddLast(T data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void Remove(T data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && !current.Next.Data.Equals(data))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}