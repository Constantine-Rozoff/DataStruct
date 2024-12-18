namespace DataStructInterfaces;

public class ListChangedEventArgs<T> : EventArgs
{
    public ChangeType ChangeType { get; }
    public T? Item { get; }
    public int? Index { get; }

    public ListChangedEventArgs(ChangeType changeType, T? item = default, int? index = null)
    {
        ChangeType = changeType;
        Item = item;
        Index = index;
        
    }
}