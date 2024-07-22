using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(4);

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);

        Console.WriteLine("Graph representation:");
        graph.PrintGraph();

        Console.WriteLine("\nDepth First Traversal (starting from vertex 2):");
        graph.DFS(2);

        Console.WriteLine("\nBreadth First Traversal (starting from vertex 2):");
        graph.BFS(2);

        Console.WriteLine("\nChecking if path exists between vertices:");
        Console.WriteLine("Path from 1 to 3: " + graph.HasPath(1, 3));
        Console.WriteLine("Path from 3 to 1: " + graph.HasPath(3, 1));

        Console.WriteLine("\nShortest path from 0 to 3:");
        List<int> shortestPath = graph.ShortestPath(0, 3);
        Console.WriteLine(string.Join(" -> ", shortestPath));
    }
}

class Graph
{
    private int V; // Number of vertices
    private List<int>[] adj; // Adjacency list

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void PrintGraph()
    {
        for (int i = 0; i < V; i++)
        {
            Console.Write($"Vertex {i}: ");
            foreach (int neighbor in adj[i])
            {
                Console.Write($"{neighbor} ");
            }
            Console.WriteLine();
        }
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[V];
        DFSUtil(v, visited);
        Console.WriteLine();
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int neighbor in adj[v])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
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

            foreach (int neighbor in adj[s])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        Console.WriteLine();
    }

    public bool HasPath(int start, int end)
    {
        bool[] visited = new bool[V];
        return HasPathUtil(start, end, visited);
    }

    private bool HasPathUtil(int current, int end, bool[] visited)
    {
        if (current == end)
            return true;

        visited[current] = true;

        foreach (int neighbor in adj[current])
        {
            if (!visited[neighbor])
            {
                if (HasPathUtil(neighbor, end, visited))
                    return true;
            }
        }

        return false;
    }

    public List<int> ShortestPath(int start, int end)
    {
        bool[] visited = new bool[V];
        int[] parent = new int[V];
        for (int i = 0; i < V; i++)
        {
            parent[i] = -1;
        }

        Queue<int> queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            int current = queue.Dequeue();

            if (current == end)
            {
                return ReconstructPath(parent, start, end);
            }

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return new List<int>(); // No path found
    }

    private List<int> ReconstructPath(int[] parent, int start, int end)
    {
        List<int> path = new List<int>();
        for (int at = end; at != -1; at = parent[at])
        {
            path.Add(at);
        }
        path.Reverse();
        return path;
    }
}