namespace DataStructInterfaces;

public interface IDoubleLinkedList<T> : IMyCollection<T>
{
    void AddFirst(T value);
    void Insert(int index, T value);
    void PrintLinkedList();
    void RemoveFirst();
    void RemoveLast();
}