using System;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        // Insert nodes
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(70);
        bst.Insert(60);
        bst.Insert(80);

        Console.WriteLine("Binary Search Tree Operations:");

        Console.Write("In-order traversal: ");
        bst.InOrderTraversal();
        Console.WriteLine();

        int searchValue = 40;
        Console.WriteLine($"Search for {searchValue}: {bst.Search(searchValue)}");

        int deleteValue = 30;
        bst.Delete(deleteValue);
        Console.WriteLine($"After deleting {deleteValue}:");
        Console.Write("In-order traversal: ");
        bst.InOrderTraversal();
        Console.WriteLine();

        Console.WriteLine($"Minimum value: {bst.FindMin()}");
        Console.WriteLine($"Maximum value: {bst.FindMax()}");

        Console.WriteLine($"Tree height: {bst.Height()}");

        Console.WriteLine($"Is BST valid: {bst.IsBST()}");
    }
}

class BinarySearchTree
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

    public BinarySearchTree()
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

    public void Delete(int data)
    {
        root = DeleteRec(root, data);
    }

    private Node DeleteRec(Node root, int data)
    {
        if (root == null) return root;

        if (data < root.Data)
            root.Left = DeleteRec(root.Left, data);
        else if (data > root.Data)
            root.Right = DeleteRec(root.Right, data);
        else
        {
            // Node with only one child or no child
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            root.Data = MinValue(root.Right);

            // Delete the inorder successor
            root.Right = DeleteRec(root.Right, root.Data);
        }

        return root;
    }

    private int MinValue(Node root)
    {
        int minv = root.Data;
        while (root.Left != null)
        {
            minv = root.Left.Data;
            root = root.Left;
        }
        return minv;
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

    public bool IsBST()
    {
        return IsBSTUtil(root, int.MinValue, int.MaxValue);
    }

    private bool IsBSTUtil(Node node, int min, int max)
    {
        if (node == null)
            return true;

        if (node.Data < min || node.Data > max)
            return false;

        return (IsBSTUtil(node.Left, min, node.Data - 1) &&
                IsBSTUtil(node.Right, node.Data + 1, max));
    }
}
