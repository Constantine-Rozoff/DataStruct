using System.Collections;
using DataStructInterfaces;

namespace DataStructLib;

public class MyLinkedList<T> : IMyLinkedList<T>, IEnumerable<T>
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

    protected Node? Root { get;  set; }
    protected Node? last { get;  set; }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new LinkedListIterator(Root!);
    }
        
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
        
    private class LinkedListIterator : IEnumerator<T>
    {
        private readonly Node? _firstNode;
        private Node _node;

        public LinkedListIterator(Node node)
        {
            _firstNode = _node = node;
        }

        public T Current => _node.Value!;

        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            var next = _node.Next;
            _node = next;
            return next != null;
        }

        public void Reset()
        {
            _node = _firstNode!;
        }

        public void Dispose()
        {
        }
    }

    public event EventHandler<ListChangedEventArgs<T>>? ListChanged;
    
    public void OnListChanged(ChangeType changeType,
        T? item = default,
        int? index = null)
    {
        ListChanged?.Invoke(this, new ListChangedEventArgs<T>(changeType, item, index));
    }

    public MyLinkedList()
    {
        Root = default;
        last = default;
    }

    public int Count { get; protected set; }
    
    public T? First
    {
        get
        {
            if (Root == default)
                throw new InvalidOperationException("Empty Linked List");
            return Root.Value;
        }
    }

    public T? Last
    {
        get
        {
            if (Root == null)
                throw new InvalidOperationException("Список пуст.");

            Node current = Root;
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
        newNode.Next = Root;
        Root = newNode;
        Count++;
        OnListChanged(ChangeType.Add, value, Count - 1);
    }
    
    public virtual void Add(T value)
    {
        Node newNode = CreateNode(value);

        if (Root == default)
        {
            AddFirst(value);
            last = Root;
        }
        else
        {
            Node current = Root;
            while (current.Next != default)
            {
                current = current.Next;
            }

            current.Next = newNode;

            last = newNode;

            Count++;
            OnListChanged(ChangeType.Add, value, Count - 1);
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
            newNode.Next = Root;
            Root = newNode;
            return;
        }
        
        current = Root;
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
        OnListChanged(ChangeType.Insert, value, index);
    }

    public virtual bool Contains(T value)
    {
        Node current = Root;
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
        Root = default;
        Count = 0;
        OnListChanged(ChangeType.Clear, default, 0);
    }
    
    public virtual T[] ToArray()
    {
        int count = 0;
        Node current = Root;
        while (current != default)
        {
            count++;
            current = current.Next;
        }

        T[] array = new T[count];

        current = Root;
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
        Node current = Root;
        while (current != default)
        {
            Console.Write(current.Value! + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}