using System.Collections;
using DataStructInterfaces;

namespace DataStructLib;

public class DoubleLinkedList<T> : MyLinkedList<T>, IEnumerable<T>
{
    protected class DoubleNode : Node
    {
        public Node? Prev { get; set; }

        public DoubleNode(T? value, Node? next, Node? prev) : base(value, next)
        {
            Next = next;
            Prev = prev;
            Value = value;
        }
    }
    
    public new IEnumerator<T> GetEnumerator()
    {
        return new DoubleLinkedListIterator((DoubleNode)Root!);
    }
        
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
        
    private class DoubleLinkedListIterator : IEnumerator<T>
    {
        private readonly DoubleNode? _firstNode;
        private DoubleNode _node;
        private DoubleNode _prev;

        public DoubleLinkedListIterator(DoubleNode node, DoubleNode prev = null)
        {
            _prev = prev;
            _firstNode = _node = node;
        }

        public T Current => _node.Value!;

        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            if (_node == null)
                return false;
            
            DoubleNode next = (DoubleNode)_node.Next!;
            if (next != null)
            {
                next.Prev = _node.Prev;
            }
            if (_node.Prev != null)
            {
                _node.Prev.Next = next;
            }
            _node = next;
            return _node != null;
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
    
    private void OnListChanged(
        ChangeType changeType,
        T? item = default,
        int? index = null)
    {
        ListChanged?.Invoke(this, new ListChangedEventArgs<T>(changeType, item, index));
    }

    protected override Node CreateNode(T? value, Node? next = null, Node? prev = null)
    {
        return new DoubleNode(value, next, prev); 
    }
    
    public void Remove(T value)
    {
        Node? current = Root;

        if (Root == null)
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
        OnListChanged(ChangeType.Remove, value);
    }
    
    public void RemoveFirst()
    {
        if (Root == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        if (Root != null && Root.Next == null)
        {
            Root = (last = default) as DoubleNode;
        }
        else
        {
            var node = (DoubleNode)Root.Next!;
            Root = node;
            node!.Prev = default;
        }

        Count--;
        OnListChanged(ChangeType.Remove, Root!.Value, 0);
    }
    
    public void RemoveLast()
    {
        if (last == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        Node? current = Root;
        while (current!.Next != default)
        {
            current = current.Next;
        }
        
        OnListChanged(ChangeType.Remove, last!.Value, Count - 1);

        var node = (DoubleNode)current;
        last = node.Prev;
        current.Value = default;
        
        Count--;
    }
    
    public override void Clear()
    {
        Root = default;
        Count = 0;
        OnListChanged(ChangeType.Clear, default, 0);
    }
    
    public override void PrintLinkedList()
    {
        Node? current = Root;
        while (current != default)
        {
            Console.Write(current.Value! + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}