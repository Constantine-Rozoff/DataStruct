namespace DataStructInterfaces;

public interface IMyLinkedList<T> : IMyCollection<T>
{
    void AddFirst(T value);
    void Insert(int index, T value);
    void PrintLinkedList();
    T?[] ToArray();
}