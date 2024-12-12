using DataStructInterfaces;

namespace DataStructLib;

public class MyLinkedList<T> : IMyLinkedList<T>
{
    private class Node : IListNode<T>
    {
        public IListNode<T>? Next { get; set; }
        public T? Value { get; set; }
        public IListNode<T> CreateNode(T value)
        {
            return new Node(value);
        }

        public Node(T? value)
        {
            Value = value;
            Next = null;
        }
    }
    
    protected IListNode<T>? root;
    protected IListNode<T>? last;
    public int Count { get; protected set; }
    
    public T? First
    {
        get
        {
            if (root == default)
                throw new InvalidOperationException("Empty Linked List");
            return (T?)root.Value;
        }
    }

    public T? Last
    {
        get
        {
            if (root == null)
                throw new InvalidOperationException("Список пуст.");

            IListNode<T> current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }

    public MyLinkedList()
    {
        root = default;
        last = default;
    }

    private IListNode<T> CreateNode(T value)
    {
        IListNode<T> node = new Node(value);
        return node;
    }


    public virtual void AddFirst(T value)
    {
        var newNode = CreateNode(value);
        newNode.Next = root;
        root = newNode;
        Count++;
    }
    
    public virtual void Add(T value)
    {
        IListNode<T>? newNode = CreateNode(value);

        if (root == default)
        {
            AddFirst(value);
        }
        else
        {
            IListNode<T>? current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Count++;
        }
    }
    
    public void Insert(int index, T value)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        IListNode<T> newNode = new Node(value);
        int currentIndex = 0;
        IListNode<T>? current = default;

        if (index == 0)
        {
            newNode.Next = root;
            root = newNode;
            return;
        }
        
        current = root;
        while (current != default && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }
        
        if (current == default) 
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }

        newNode.Next = current.Next;
        current.Next = newNode;
        Count++;
    }

    public virtual bool Contains(T value)
    {
        IListNode<T>? current = root;
        while (current != default)
        {
            if (current.Value!.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }
        return false;
    }
    
    public virtual void Clear()
    {
        root = default;
        Count = 0;
    }
    
    public virtual T[] ToArray()
    {
        int count = 0;
        IListNode<T>? current = root;
        while (current != default)
        {
            count++;
            current = current.Next;
        }

        T[] array = new T[count];

        current = root;
        int index = 0;
        while (current != default)
        {
            array[index] = (T)current.Value!;
            current = current.Next;
            index++;
        }

        return array;
    }
    
    public virtual void PrintLinkedList()
    {
        IListNode<T>? current = root;
        while (current != default)
        {
            Console.Write(current.Value! + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}