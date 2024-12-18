namespace DataStructInterfaces;

public interface IMyCollection<T>
{
    int Count { get; }

    void Add(T item);
    bool Contains(T item);
    T?[] ToArray();
    void Clear();
}