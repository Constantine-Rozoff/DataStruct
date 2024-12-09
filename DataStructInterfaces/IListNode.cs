namespace DataStructInterfaces;

public interface IListNode
{
    IListNode? Next { get; set; }
    object Value { get; set; }    
}