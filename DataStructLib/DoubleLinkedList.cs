namespace DataStructLib;

public class DoubleLinkedList<T> : MyLinkedList<T>
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

    protected override Node CreateNode(T? value, Node? next = null, Node? prev = null)
    {
        return new DoubleNode(value, next, prev); 
    }
    
    public void Remove(T value)
    {
        Node? current = root;

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
            root = (last = default) as DoubleNode;
        }
        else
        {
            var node = (DoubleNode)root.Next!;
            root = node;
            node!.Prev = default;
        }

        Count--;
    }
    
    public void RemoveLast()
    {
        if (last == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        Node? current = root;
        while (current!.Next != default)
        {
            current = current.Next;
        }

        var node = (DoubleNode)current;
        last = node.Prev;
        current.Value = default;
        
        Count--;
    }
    
    public override void Clear()
    {
        root = default;
        Count = 0;
    }
    
    public override void PrintLinkedList()
    {
        Node? current = root;
        while (current != default)
        {
            Console.Write(current.Value! + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}