namespace DataStructInterfaces;

public interface IMyList : IMyCollection
{
    int Count { get; }
    object this[int index] { get; set; }
    
    void MyInsert(int index, object item);
    int MyIndexOf(IMyList item);
    void MyRemoveAt(int index);
    bool MyRemove(object item);
    void MyReverse();
    void MyClear();
}