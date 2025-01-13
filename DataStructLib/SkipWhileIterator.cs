using System.Collections;

namespace DataStructLib;

public class SkipWhileIterator<T> : IEnumerator<T>
{
    private readonly IEnumerator<T> _baseIterator;
    private readonly Func<T, bool> _filter;
    private bool _skip = true;

    public T Current => _baseIterator.Current;

    object IEnumerator.Current => Current;

    public SkipWhileIterator(IEnumerator<T> baseIterator, Func<T, bool> filter)
    {
        this._baseIterator = baseIterator;
        this._filter = filter;
    }

    public bool MoveNext()
    {
        start: var result = _baseIterator.MoveNext();
        if (_skip)
        {
            if (!result)
            {
                return false;
            }

            if (_filter(_baseIterator.Current))
            {
                goto start;
            }
            else
            {
                return true;
            }
        }
        return result;
    }

    public void Reset()
    {
    }

    public void Dispose()
    {
    }
}