using DataStructInterfaces;

namespace DataStructLib;

public class BinaryTree<T> : IMyCollection<T> where T : IComparable<T>
{
    private class Node<T> : ITreeNode<T>
    {
        public Node(T value, ITreeNode<T>? left = null, ITreeNode<T>? right = null)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public ITreeNode<T>? Left { get; set; }
        public ITreeNode<T>? Right { get; set; }
        public T? Value { get; init; }
    }

    private ITreeNode<T>? _root;
    public int Count { get; private set; }
    
    public event EventHandler<ListChangedEventArgs<T>>? ListChanged;
    
    private void OnListChanged(
        ChangeType changeType,
        T? item = default,
        int? index = null)
    {
        ListChanged?.Invoke(this, new ListChangedEventArgs<T>(changeType, item, index));
    }
    
    public void Add(T item)
    {
        if (_root == default)
        {
            _root = new Node<T>(item);
        }
        else
        {
            Add(_root, item);
        }
        
        Count++;
        OnListChanged(ChangeType.Add, item, Count - 1);
    }

    private void Add(ITreeNode<T>? current, T item)
    {
        if (current != default && item.CompareTo(current.Value) < 0)
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
        else if (current != null && item.CompareTo(current.Value) > 0)
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

    public bool Contains(T? item)
    {
        return _root != default && Contains(_root, item);
    }

    private bool Contains(ITreeNode<T>? current, T? item)
    {
        if (current != default && (item!.CompareTo(current.Value)) < 0 )
        {
            if (current.Left == null)
            {
                return false;
            }

            return Contains(current.Left, item);
        }
        else
        {
            if (current != default && item!.CompareTo(current.Value) > 0)
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

    public T[] ToArray()
    {
        T[] newArray = new T[Count];
        int index = 0;

        if (_root != default) 
            InOrderTraversal(_root, newArray, ref index);
        
        return newArray;
    }
    
    private void InOrderTraversal(ITreeNode<T>? node, T[] newArray, ref int index)
    {
        if (node != default)
        {
            
            if (node.Left != default) 
                InOrderTraversal(node.Left, newArray, ref index);
            
            newArray[index] = node.Value;
            index++;
            
            if (node.Right != default) 
                InOrderTraversal(node.Right, newArray, ref index);
        }
    }

    public void Clear()
    {
        _root = null;
        Count = 0;
        OnListChanged(ChangeType.Clear, default, 0);
    }
}