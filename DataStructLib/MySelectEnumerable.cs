using System.Collections;

namespace DataStructLib;

public class MySelectEnumerable<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> collection;
    private readonly Func<T, bool> selector;

    public MySelectEnumerable(IEnumerable<T> collection, Func<T, bool> selector)
    {
        this.collection = collection;
        this.selector = selector;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MySelectIterator<T>(collection.GetEnumerator(), selector);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}