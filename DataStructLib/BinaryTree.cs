using DataStructInterfaces;

namespace DataStructLib;

public class BinaryTree<T>
{
    public class Node<T> : ITreeNode<T>
    {
        public Node(int value, ITreeNode<T>? left = null, ITreeNode<T>? right = null)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public ITreeNode<T>? Left { get; set; }
        public ITreeNode<T>? Right { get; set; }
        public int Value { get; init; }
    }

    private ITreeNode<T>? _root;
    public int Count { get; private set; }
    
    
    public void Add(int item)
    {
        if (_root == null)
        {
            _root = new Node<T>(item);
        }
        else
        {
            Add(_root, item);
        }
        
        Count++;
    }

    private void Add(ITreeNode<T>? current, int item)
    {
        if (current != default && item < current.Value)
        {
            if (current.Left == null)
            {
                current.Left = new Node<T>(item);
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
                current.Right = new Node<T>(item);
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

    private bool Contains(ITreeNode<T>? current, int item)
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

        if (_root != default) 
            InOrderTraversal(_root, newArray, ref index);
        
        return newArray;
    }
    
    private void InOrderTraversal(ITreeNode<T>? node, int[] newArray, ref int index)
    {
        if (node != default)
        {
            
            if (node.Left != default) 
                InOrderTraversal(node.Left, newArray, ref index);
            
            newArray[index] = node.Value;
            index++;
            
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