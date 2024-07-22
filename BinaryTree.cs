using System;

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Insert nodes
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(1);
        tree.Insert(9);
        tree.Insert(6);
        tree.Insert(4);

        Console.WriteLine("Binary Tree Traversals:");

        Console.Write("In-order traversal: ");
        tree.InOrderTraversal();
        Console.WriteLine();

        Console.Write("Pre-order traversal: ");
        tree.PreOrderTraversal();
        Console.WriteLine();

        Console.Write("Post-order traversal: ");
        tree.PostOrderTraversal();
        Console.WriteLine();

        // Search for a value
        int searchValue = 6;
        bool found = tree.Search(searchValue);
        Console.WriteLine($"\nIs {searchValue} in the tree? {found}");

        // Find minimum and maximum values
        Console.WriteLine($"Minimum value: {tree.FindMin()}");
        Console.WriteLine($"Maximum value: {tree.FindMax()}");

        // Calculate height of the tree
        Console.WriteLine($"Height of the tree: {tree.Height()}");
    }
}

class BinaryTree
{
    private class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    private Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
            root.Left = InsertRec(root.Left, data);
        else if (data > root.Data)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRec(root);
    }

    private void InOrderTraversalRec(Node root)
    {
        if (root != null)
        {
            InOrderTraversalRec(root.Left);
            Console.Write(root.Data + " ");
            InOrderTraversalRec(root.Right);
        }
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversalRec(root);
    }

    private void PreOrderTraversalRec(Node root)
    {
        if (root != null)
        {
            Console.Write(root.Data + " ");
            PreOrderTraversalRec(root.Left);
            PreOrderTraversalRec(root.Right);
        }
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversalRec(root);
    }

    private void PostOrderTraversalRec(Node root)
    {
        if (root != null)
        {
            PostOrderTraversalRec(root.Left);
            PostOrderTraversalRec(root.Right);
            Console.Write(root.Data + " ");
        }
    }

    public bool Search(int data)
    {
        return SearchRec(root, data);
    }

    private bool SearchRec(Node root, int data)
    {
        if (root == null || root.Data == data)
            return root != null;

        if (root.Data > data)
            return SearchRec(root.Left, data);

        return SearchRec(root.Right, data);
    }

    public int FindMin()
    {
        if (root == null)
            throw new InvalidOperationException("Tree is empty");

        Node current = root;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current.Data;
    }

    public int FindMax()
    {
        if (root == null)
            throw new InvalidOperationException("Tree is empty");

        Node current = root;
        while (current.Right != null)
        {
            current = current.Right;
        }
        return current.Data;
    }

    public int Height()
    {
        return HeightRec(root);
    }

    private int HeightRec(Node root)
    {
        if (root == null)
            return 0;

        int leftHeight = HeightRec(root.Left);
        int rightHeight = HeightRec(root.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}