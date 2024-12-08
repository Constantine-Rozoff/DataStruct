namespace DataStructInterfaces;

public interface IMyCollection
{
    public int Count { get;  set; }
    
    void Add(object item);
    bool Contains(object item);
    public object[] ToArray();
    public void Clear();
}