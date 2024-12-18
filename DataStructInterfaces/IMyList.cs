namespace DataStructInterfaces;

public interface IMyList<T> : IMyCollection<T>
{
    T this[int index] { get; set; }
    
    void Insert(int index, T item);
    int IndexOf(T item);
    void RemoveAt(int index, T item = default);
    bool Remove(T item);
    void Reverse();
}