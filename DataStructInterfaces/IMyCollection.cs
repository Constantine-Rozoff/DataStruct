namespace DataStructInterfaces;

public interface IMyCollection<T>
{
    int Count { get; }
    
    bool Contains(T item);
    T?[] ToArray();
    void Clear();
}