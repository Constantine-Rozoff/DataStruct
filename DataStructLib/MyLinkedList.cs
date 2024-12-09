using DataStructInterfaces;

namespace DataStructLib;

public class MyLinkedList : IMyLinkedList
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
    
    public object? First
    {
        get
        {
            if (root == null)
                throw new InvalidOperationException("Empty Linked List");
            return root.Value;
        }
    }

    public object? Last
    {
        get
        {
            if (root == null)
                throw new InvalidOperationException("Список пуст.");

            IListNode current = root;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }

    public MyLinkedList()
    {
        root = null;
        last = null;
    }


    public void AddFirst(object value)
    {
        Node? newNode = new Node(value);
        newNode.Next = root;
        root = newNode;
        Count++;
    }
    
    public void Add(object value)
    {
        Node? newNode = new Node(value);

        if (root == null)
        {
            AddFirst(value);
        }
        else
        {
            IListNode current = root;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Count++;
        }
    }
    
    public void Insert(int index, object value)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        IListNode? newNode = new Node(value);
        int currentIndex = 0;
        IListNode? current = null;

        if (index == 0)
        {
            newNode.Next = root;
            root = newNode;
            return;
        }
        
        current = root;
        while (current != null && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }
        
        if (current == null) 
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }

        newNode.Next = current.Next;
        current.Next = newNode;
        Count++;
    }

    public bool Contains(object value)
    {
        IListNode? current = root;
        while (current != null)
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
        root = null;
        Count = 0;
    }
    
    public object[] ToArray()
    {
        int count = 0;
        IListNode? current = root;
        while (current != null)
        {
            count++;
            current = current.Next;
        }

        object[] array = new object[count];

        current = root;
        int index = 0;
        while (current != null)
        {
            array[index] = current.Value;
            current = current.Next;
            index++;
        }

        return array;
    }
    
    public void PrintLinkedList()
    {
        IListNode? current = root;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}