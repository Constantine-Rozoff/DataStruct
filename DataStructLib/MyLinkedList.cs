using DataStructInterfaces;

namespace DataStructLib;

public class MyLinkedList<T> : IMyLinkedList<T>, IMyNotifier<T>
{
    protected class Node
    {
        public Node? Next { get; set; }
        public T? Value { get; set; }

        public Node(T? value, Node? next = null)
        {
            Value = value;
            Next = next;
        }
    }

    protected Node? root;
    protected Node? last;
    private List<IMyObserver<T>> _observers = new ();


    public MyLinkedList()
    {
        root = default;
        last = default;
    }

    public int Count { get; protected set; }
    
    public T? First
    {
        get
        {
            if (root == default)
                throw new InvalidOperationException("Empty Linked List");
            return root.Value;
        }
    }

    public T? Last
    {
        get
        {
            if (root == null)
                throw new InvalidOperationException("Список пуст.");

            Node current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }
    
    protected virtual Node CreateNode(T? value, Node? next = null, Node? prev = null)
    {
        return new Node(value, next);
    }

    public void AddFirst(T value)
    {
        var newNode = CreateNode(value);
        newNode.Next = root;
        root = newNode;
        Count++;
        Notify(ChangeType.Add, value, Count - 1);
    }
    
    public virtual void Add(T value)
    {
        Node newNode = CreateNode(value);

        if (root == default)
        {
            AddFirst(value);
            last = root;
        }
        else
        {
            Node current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }

            current.Next = newNode;

            last = newNode;

            Count++;
            Notify(ChangeType.Add, value, Count - 1);
        }
    }
    
    public void Insert(int index, T value)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        Node newNode = new Node(value);
        int currentIndex = 0;
        Node? current = default;

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
        Notify(ChangeType.Insert, value, index);
    }

    public virtual bool Contains(T value)
    {
        Node current = root;
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
        Notify(ChangeType.Clear, default, 0);
    }
    
    public virtual T[] ToArray()
    {
        int count = 0;
        Node current = root;
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
        Node current = root;
        while (current != default)
        {
            Console.Write(current.Value! + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public void Subscribe(IMyObserver<T> observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IMyObserver<T> observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(ChangeType changeType, T? item = default, int? index = null)
    {
        foreach (var observer in _observers)
        {
            observer.OnListChanged(changeType, item, index);
            
            Console.WriteLine($"Method: {changeType.ToString()}, Item: {item}, Index: {index.ToString()}");
        }
    }
}