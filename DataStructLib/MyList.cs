namespace DataStructLib;

public class MyList
{
    private object[] _innerArray = new object[10];
    
    public int Count { get; private set; }

    public object this[int i]
    {
        get
        {
            if (i < 0 || i > _innerArray.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            
            return _innerArray[i];
        }
        
        set
        {
            if (i < 0 || i > _innerArray.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            
            if (_innerArray[i].Equals(null))
            {
                throw new InvalidOperationException("Index points on null value");
            }
            
            _innerArray[i] = value;
        }
    }
    
    public void MyAdd(object item)
    {
        _innerArray = Increase();
        
        _innerArray[Count] = item;
        Count++;
    }

    private object[] Increase()
    {
        int newSize = _innerArray.Length * 2;
    
        object[] newArray = new object[newSize];
    
        MyCopy(newArray, _innerArray, Count);

        _innerArray = newArray;

        return _innerArray;
    }
    
    private void MyCopy(
        object[] destinationArray,
        object[] copiedArray,
        int count)
    {
        for (int i = 0; i < count; i++)
        {
            destinationArray[i] = copiedArray[i];
        }
    }
    
    public void MyInsert(int index, object item)
    {
        if (index < 0 || index > _innerArray.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        var newArray = Increase();
        
        MyCopy(newArray, _innerArray, index);
        
        newArray[index] = item;

        for (int i = index; i < _innerArray.Length - 1; i++)
        {
            newArray[i + 1] = _innerArray[i];
        }

        _innerArray = newArray;
        Count++;
    }
    
    public int MyIndexOf(object item)
    {
        for (int i = 0; i < _innerArray.Length; i++)
        {
            if (_innerArray[i] != null && _innerArray[i].Equals(item))
            {
                return i;
            }
        }

        return 0;
    }
    
    public bool MyContains(object item)
    {
        if (MyIndexOf(item) >= 0) { return true; }

        return false;
    }
    
    public void MyReverse()
    {
        int left = 0;
        int right = Count - 1;

        while (left < right)
        {
            var temp = _innerArray[left];
            _innerArray[left] = _innerArray[right];
            _innerArray[right] = temp;

            left++;
            right--;
        }
    }
    
    public bool MyRemove(object item)
    {
        int index = MyIndexOf(item);
        if (index >= 0)
        {
            MyRemoveAt(index);
            return true;
        }

        return false;
    }
    
    public void MyRemoveAt(int index)
    {
        if (index < 0 || index > _innerArray.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        for (int i = index; i < _innerArray.Length - 1; i++)
        {
            _innerArray[i] = _innerArray[i + 1];
        }

        _innerArray[^1] = default!;
    }
    
    public void MyClear()
    {
        for (int i = 0; i < _innerArray.Length; i++)
        {
            _innerArray[i] = default!;
        }
    }
    
    public object[] MyToArray()
    {
        object[] newArray = new object[Count];
        
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _innerArray[i]!;
        }
        
        return newArray;
    }
}