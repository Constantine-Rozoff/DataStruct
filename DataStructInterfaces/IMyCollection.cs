namespace DataStructInterfaces;

public interface IMyCollection<T>
{
    public int Count { get; }
    
    void Add(T item);
    bool Contains(T item);
    public void Clear();
}