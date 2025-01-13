using System.Collections;

namespace DataStructLib;

public class MySelectIterator<T> : IEnumerator<T>
{
    private readonly IEnumerator<T> _baseIterator;
    private readonly Func<T, bool> _selector;
    public T Current => _baseIterator.Current;
    
    object IEnumerator.Current => Current;

    public MySelectIterator(IEnumerator<T> baseIterator, Func<T, bool> selector)
    {
        _baseIterator = baseIterator;
        _selector = selector;
    }
    
    public bool MoveNext()
    {
        start: var result = _baseIterator.MoveNext();
        if (!result)
        {
            return false;
        }
        
        if (_selector(_baseIterator.Current))
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