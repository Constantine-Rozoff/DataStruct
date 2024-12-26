using System.Collections;

namespace DataStructLib;

public class SkipWhileEnumerable<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> collection;
    private readonly Func<T, bool> filter;

    public SkipWhileEnumerable(IEnumerable<T> collection, Func<T, bool> filter)
    {
        this.collection = collection;
        this.filter = filter;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new SkipWhileIterator<T>(collection.GetEnumerator(), filter);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}