using DataStructInterfaces;

namespace DataStructLib;

public class MyLinkedList<T> : IMyLinkedList<T>
{
    public class Node : IListNode
    {
        public IListNode? Next { get; set; }
        public object Value { get; set; }

        public Node(object value)
        {
            Value = value;
            Next = null;
        }
    }
    
    private IListNode root;
    private Node? last;
    public int Count { get; private set; }
    
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

            IListNode current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }
            return (T?)current.Value;
        }
    }

    public MyLinkedList()
    {
        root = default;
        last = default;
    }


    public void AddFirst(T value)
    {
        Node? newNode = new Node(value);
        newNode.Next = root;
        root = newNode;
        Count++;
    }
    
    public void Add(T value)
    {
        Node? newNode = new Node(value);

        if (root == default)
        {
            AddFirst(value);
        }
        else
        {
            IListNode current = root;
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
        
        IListNode? newNode = new Node(value);
        int currentIndex = 0;
        IListNode? current = default;

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

    public bool Contains(T value)
    {
        IListNode? current = root;
        while (current != default)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }
        return false;
    }
    
    public void Clear()
    {
        root = default;
        Count = 0;
    }
    
    public T[] ToArray()
    {
        int count = 0;
        IListNode? current = root;
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
            array[index] = (T)current.Value;
            current = current.Next;
            index++;
        }

        return array;
    }
    
    public void PrintLinkedList()
    {
        IListNode? current = root;
        while (current != default)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}