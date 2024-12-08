namespace DataStructInterfaces;

public interface IMyList : IMyCollection
{
    object this[int index] { get; set; }
    
    void Insert(int index, object item);
    int IndexOf(object item);
    void RemoveAt(int index);
    bool Remove(object item);
    void Reverse();
}