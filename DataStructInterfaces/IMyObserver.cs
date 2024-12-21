namespace DataStructInterfaces;

public interface IMyObserver<T>
{
    public void OnListChanged(ChangeType changeType, T? item = default, int? index = null);
}