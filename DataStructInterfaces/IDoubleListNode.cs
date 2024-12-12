namespace DataStructInterfaces;

public interface IDoubleListNode<T>
{
    IDoubleListNode<T>? Next { get; set; }
    IDoubleListNode<T>? Prev { get; set; }
    T? Value { get; set; }   
    
    //IDoubleListNode<T> CreateNode(T value);
}