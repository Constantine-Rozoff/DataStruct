namespace DataStructInterfaces;

public interface IMyLinkedList : IMyCollection
{
    public abstract class Node;
    
    public void AddFirst(object value);
    public void Insert(int index, object value);
    public void PrintLinkedList();
}