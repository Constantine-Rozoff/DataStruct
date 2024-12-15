namespace DataStructInterfaces;

public interface IListNode<T>
{
    IListNode<T>? Next { get; set; }
    T? Value { get; set; }

    IListNode<T> CreateNode(T value);
}