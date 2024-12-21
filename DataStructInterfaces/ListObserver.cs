namespace DataStructInterfaces;

public class ListObserver<T> : IMyObserver<T>
{
    public event EventHandler<ListChangedEventArgs<T>>? ListChanged;
    
    public void OnListChanged(ChangeType changeType,
        T? item = default,
        int? index = null)
        {
            ListChanged?.Invoke(this, new ListChangedEventArgs<T>(changeType, item, index));
        }
}