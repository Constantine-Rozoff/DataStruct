using System.Collections;

namespace DataStructLib;

public class FilterIterator<T> : IEnumerator<T>
{
    private readonly IEnumerator<T> _baseIterator;
    private readonly Func<T, bool> _filter;
    public T Current => _baseIterator.Current;
    
    object IEnumerator.Current => Current;

    public FilterIterator(IEnumerator<T> baseIterator, Func<T, bool> filter)
    {
        _baseIterator = baseIterator;
        _filter = filter;
    }
    
    public bool MoveNext()
    {
        start: var result = _baseIterator.MoveNext();
        if (!result)
        {
            return false;
        }

        if (_filter(_baseIterator.Current))
        {
            return true;
        }
        else
        {
            goto start;
        }
    }

    public void Reset()
    {
    }

    public void Dispose()
    {
    }
}