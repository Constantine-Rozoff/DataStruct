using DataStructInterfaces;

namespace DataStructLib;

public class MyStack<T> : IMyCollection<T>
{
    public int Count { get; private set; }
    private List<T> items;
    
    public event EventHandler<ListChangedEventArgs<T>>? ListChanged;
    
    public void OnListChanged(ChangeType changeType,
        T? item = default,
        int? index = null)
    {
        ListChanged?.Invoke(this, new ListChangedEventArgs<T>(changeType, item, index));
    }
    
    public MyStack()
    {
        items = new List<T>();
    }
    
    public T? this[int i]
    {
        get
        {
            if (i < 0 || i > Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            
            return items[i];
        }
        
        set
        {
            if (i < 0 || i > Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            
            items[i] = (T)value;
        }
    }
    
    void IMyCollection<T>.Add(T item)
    {
        Push(item);
        OnListChanged(ChangeType.Add, item, Count - 1);
    }
    
    public void Push(T item)
    {
        items.Add(item);
        Count++;
        OnListChanged(ChangeType.Add, item, Count - 1);
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var topItem = items[^1];
        items.RemoveAt(items.Count - 1);
        Count--;
        OnListChanged(ChangeType.Remove, items[items.Count - 1], items.Count - 1);
        return topItem;
    }
    
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[^1];
    }

    public bool Contains(T item)
    {
        if (IndexOf(item) >= 0) { return true; }

        return false;
    }

    private int IndexOf(T item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null && items[i]!.Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public T?[] ToArray()
    {
        T[] newArray = new T[Count];
        
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = items[i]!;
        }
        
        return newArray;
    }

    public void Clear()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i] = default!;
        }

        OnListChanged(ChangeType.Clear, default, 0);
        Count = 0;
    }
    
        
    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void PrintStack() 
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }
}