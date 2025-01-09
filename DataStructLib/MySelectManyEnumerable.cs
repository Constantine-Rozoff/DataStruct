using System.Collections;

namespace DataStructLib;

public class MySelectManyEnumerable<T, TResult> : IEnumerable<TResult>
{
    private readonly IEnumerable<T> collection;
    private readonly Func<T, IEnumerable<TResult>> selector;

    public MySelectManyEnumerable(IEnumerable<T> collection, Func<T, IEnumerable<TResult>> selector)
    {
        this.collection = collection;
        this.selector = selector;
    }

    public IEnumerator<TResult> GetEnumerator()
    {
        return new MySelectManyIterator<T, TResult>(collection.GetEnumerator(), selector);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}