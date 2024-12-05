namespace DataStructInterfaces;

public interface IMyCollection : IComparable
{
    void Add(object item);

    bool Contains(object item);

    public object[] MyToArray();
}