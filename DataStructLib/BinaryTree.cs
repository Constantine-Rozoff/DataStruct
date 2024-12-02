namespace DataStructLib;

public class BinaryTree
{
    public class Node
    {
        public Node(int value, Node? left = null, Node? right = null)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Value { get; init; }
    }

    private Node? _root;
    public int Count { get; private set; }
    
    
    public void Add(int item)
    {
        if (_root == null)
        {
            _root = new Node(item);
        }
        else
        {
            Add(_root, item);
        }
        
        Count++;
    }

    private void Add(Node? current, int item)
    {
        if (current != null && item < current.Value)
        {
            if (current.Left == null)
            {
                current.Left = new Node(item);
            }
            else
            {
                Add(current.Left, item);
            }
        }
        else if (current != null && item > current.Value)
        {
            if (current.Right == null)
            {
                current.Right = new Node(item);
            }
            else
            {
                Add(current.Right, item);
            }
        }
    }

    public bool Contains(int item)
    {
        return _root != null && Contains(_root, item);
    }

    private bool Contains(Node? current, int item)
    {
        if (current != null && item < current.Value)
        {
            if (current.Left == null)
            {
                return false;
            }

            return Contains(current.Left, item);
        }
        else
        {
            if (current != null && item > current.Value)
            {
                if (current.Right == null)
                {
                    return false;
                }

                return Contains(current.Right, item);
            }
            
            return true;
        }
    }

    public int[] ToArray()
    {
        int[] newArray = new int[Count];
        int index = 0;

        if (_root != null) 
            InOrderTraversal(_root, newArray, ref index);
        
        return newArray;
    }
    
    private void InOrderTraversal(Node? node, int[] newArray, ref int index)
    {
        if (node != null)
        {
            
            if (node.Left != null) 
                InOrderTraversal(node.Left, newArray, ref index);
            
            newArray[index] = node.Value;
            index++;
                //Console.WriteLine(node.Value);
            
            if (node.Right != null) 
                InOrderTraversal(node.Right, newArray, ref index);
        }
    }

    public void Clear()
    {
        _root = null;
        Count = 0;
    }
}