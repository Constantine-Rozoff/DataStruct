using DataStructInterfaces;

namespace DataStructLib;

public class DoubleLinkedList<T> : MyLinkedList<T>
{
    private IDoubleListNode<T>? root;
    private IDoubleListNode<T>? last;
    private IDoubleListNode<T>? prev;

    private class DoubleNode<T> : IDoubleListNode<T>
    {
        public IDoubleListNode<T>? Next { get; set; }
        public IDoubleListNode<T>? Prev { get; set; }
        public T? Value { get; set; }

        public DoubleNode(T? value, IDoubleListNode<T>? next = default, IDoubleListNode<T>? prev = default)
        {
            Next = default;
            Prev = default;
            Value = value;
        }

    }

    public DoubleLinkedList()
    {
        last = default;
        prev = default;
    }
    
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
                throw new InvalidOperationException("The list is empty");

            IDoubleListNode<T>? current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }
    
    private new IDoubleListNode<T> CreateNode(T value)
    {
        IDoubleListNode<T> node = new DoubleNode<T>(value); 
        return node;
    }

    
    public override void AddFirst(T value)
    {
        var newNode = CreateNode(value);
        
        if (root == null) 
        {
            root = last = newNode;
            prev = null; 
        }
        else
        {
            newNode.Next = root;  
            root.Prev = newNode;  
            root = newNode;      
        }
        
        Count++;
    }
    
    public override void Add(T value)
    {
        IDoubleListNode<T>? newNode = CreateNode(value);

        if (root == default)
        {
            AddFirst(value);
        }
        else
        {
            IDoubleListNode<T>? current = root;
            while (current.Next != default)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Count++;
        }
    }
    
    public override bool Contains(T value)
    {
        IDoubleListNode<T>? current = root;
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
    
    public void Remove(T value)
    {
        IDoubleListNode<T>? current = root;

        if (root == null)
        {
            throw new InvalidOperationException("The list is empty");
        }
        
        while (current != default)
        {
            if (current.Value!.Equals(value))
            {
                current.Value = default;
            }
    
            current = current.Next;
        }

        Count--;
    }
    
    public void RemoveFirst()
    {
        if (root == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        if (root != null && root.Next == null)
        {
            root = last = default; 
        }
        else
        {
            root = root.Next;     
            root.Prev = default;
        }

        Count--;
    }
    
    public void RemoveLast()
    {
        if (last == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        IDoubleListNode<T>? current = root;
        while (current!.Next != default)
        {
            current = current.Next;
        }

        last = current.Prev;
        //last!.Next = default;
        current.Value = default;
        
        
        // last = current.Prev; // last теперь указывает на предыдущий элемент
        //
        // // Обновляем ссылки
        // last.Next = null; // Новый последний элемент не имеет следующего
        // current.Value = default;
        
        Count--;
    }
    
    public override T[] ToArray()
    {
        int count = 0;
        IDoubleListNode<T>? current = root;
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
    
    public override void Clear()
    {
        root = default;
        Count = 0;
    }
    
    public override void PrintLinkedList()
    {
        IDoubleListNode<T>? current = root;
        while (current != default)
        {
            Console.Write(current.Value! + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}