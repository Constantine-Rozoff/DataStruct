using System.Collections;

namespace DataStructLib;

public class FilterEnumerable<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> collection;
    private readonly Func<T, bool> filter;

    public FilterEnumerable(IEnumerable<T> collection, Func<T, bool> filter)
    {
        this.collection = collection;
        this.filter = filter;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new FilterIterator<T>(collection.GetEnumerator(), filter);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}