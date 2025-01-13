using System.Collections;

namespace DataStructLib;

public class MySelectManyIterator<T, TResult> : IEnumerator<TResult>
{
    private readonly IEnumerator<T> collection;
    private readonly Func<T, IEnumerable<TResult>> selector;
    private IEnumerator<TResult> currentCollection;
    public TResult Current => currentCollection.Current;
    object? IEnumerator.Current => Current;

    public MySelectManyIterator(IEnumerator<T> collection, Func<T, IEnumerable<TResult>> selector)
    {
        this.collection = collection;
        this.selector = selector;
    }

    public bool MoveNext()
    {
        l2: if (currentCollection == null!)
        {
            l1: var result = collection.MoveNext();
            if (!result) return false;

            var current = collection.Current;
            currentCollection = selector(current).GetEnumerator();

            var result2 = currentCollection.MoveNext();
            if (!result2)
            {
                currentCollection = null;
                goto l1;
            }

            return true;
        }
        else
        {
            var result3 = currentCollection.MoveNext();
            if (!result3)
            {
                currentCollection = null;
                goto l2;
            }

            return true;
        }
    }

    public void Reset()
    {
    }

    public void Dispose()
    {
    }
}