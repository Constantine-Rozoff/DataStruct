namespace DataStructInterfaces;

public interface IMyCollection
{
    public int Count { get; }
    
    void Add(object item);
    bool Contains(object item);
    public object[] ToArray();
    public void Clear();
}