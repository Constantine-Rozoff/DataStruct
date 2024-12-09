namespace DataStructInterfaces;

public interface IMyLinkedList<T> : IMyCollection<T>
{
    public abstract class Node;
    
    public void AddFirst(T value);
    public void Insert(int index, T value);
    public void PrintLinkedList();
    public T[] ToArray();
}