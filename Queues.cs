using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a new Queue of strings
        Queue<string> queue = new Queue<string>();

        // Enqueue elements to the queue
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        // Print the queue
        Console.WriteLine("Queue elements:");
        foreach (string item in queue)
        {
            Console.WriteLine(item);
        }

        // Peek at the first element without removing it
        Console.WriteLine($"\nFirst element: {queue.Peek()}");

        // Dequeue an element from the queue
        string dequeuedItem = queue.Dequeue();
        Console.WriteLine($"Dequeued element: {dequeuedItem}");

        // Check if the queue contains a specific element
        bool containsSecond = queue.Contains("Second");
        Console.WriteLine($"\nDoes the queue contain 'Second'? {containsSecond}");

        // Get the count of elements
        Console.WriteLine($"Number of elements: {queue.Count}");

        // Clear all elements
        queue.Clear();
        Console.WriteLine($"Number of elements after clearing: {queue.Count}");

        // Example: Simulating a print queue
        Queue<string> printQueue = new Queue<string>();
        printQueue.Enqueue("Document1.pdf");
        printQueue.Enqueue("Image.jpg");
        printQueue.Enqueue("Report.docx");

        Console.WriteLine("\nPrint Queue:");
        while (printQueue.Count > 0)
        {
            string document = printQueue.Dequeue();
            Console.WriteLine($"Printing: {document}");
        }

        // Example: Breadth-First Search (BFS) using Queue
        Graph graph = new Graph(4);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);

        Console.WriteLine("\nBreadth First Traversal (starting from vertex 2):");
        graph.BFS(2);
    }
}

class Graph
{
    private int V; // Number of vertices
    private List<int>[] adj; // Adjacency Lists

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void BFS(int s)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            Console.Write(s + " ");

            foreach (int n in adj[s])
            {
                if (!visited[n])
                {
                    visited[n] = true;
                    queue.Enqueue(n);
                }
            }
        }
    }
}
