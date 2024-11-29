namespace DataStructLib;

public class MyLinkedList
{
    private Node? root;
    
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

            Node current = root;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }
    
    public int Count
    {
        get
        {
            int count = 0;
            Node? current = root;
            
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    public MyLinkedList()
    {
        root = null;
    }

    public class Node
    {
        public Node? Next { get; set; }
        public object Value { get; set; }

        public Node(object value)
        {
            Value = value;
            Next = null;
        }
    }

    public void AddFirst(object value)
    {
        Node? newNode = new Node(value);
        newNode.Next = root;
        root = newNode;
    }
    
    public void Add(object value)
    {
        Node? newNode = new Node(value);

        if (root == null)
        {
            root = newNode;
        }
        else
        {
            Node? current = root;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
    }
    
    public void Insert(int index, object value)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        Node? newNode = new Node(value);
        int currentIndex = 0;
        Node? current = null;

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
    }

    public bool Contains(object value)
    {
        Node? current = root;
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
    }
    
    public object[] ToArray()
    {
        int count = 0;
        Node? current = root;
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
        Node? current = root;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}