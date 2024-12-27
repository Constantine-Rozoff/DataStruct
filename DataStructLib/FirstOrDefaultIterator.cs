using System.Collections;

namespace DataStructLib;

public class FirstOrDefaultIterator<T> : IEnumerator<T>
{
    private readonly IEnumerator<T?> _baseIterator;
    private readonly Func<T, bool> _filter;
    private int _index = -1;
    public T? Current => _baseIterator.Current;

    object? IEnumerator.Current => Current;

    public FirstOrDefaultIterator(IEnumerator<T?> baseIterator, Func<T, bool> filter)
    {
        _baseIterator = baseIterator;
        _filter = filter;
    }
    
    public bool MoveNext()
    {
        while (_baseIterator.MoveNext())
        {
            if (_filter(_baseIterator.Current!))
            {
                return true;
            }
        }
        
        return false;
        
        //return _baseIterator.Current!.Equals(default) ? false : true;
    }
    
    public T? GetFirst()
    {
        return _baseIterator.Current!.Equals(default) ? _baseIterator.Current : default;
    }

    public void Reset()
    {
    }

    public void Dispose()
    {
    }
}