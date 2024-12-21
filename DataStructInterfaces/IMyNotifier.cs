namespace DataStructInterfaces;

public interface IMyNotifier<T>
{
    void Subscribe(IMyObserver<T> myObserver);
    void Unsubscribe(IMyObserver<T> myObserver);
    void Notify(ChangeType changeType, T? item = default, int? index = null);
}