namespace DataStructLib;

public class MyList
{
    private static object[] _innerArray = new object[10];
    
    // Clear()
    // object[] ToArray()
    
    public static object[]? MyAdd(object[] array, object item)
    {
        _innerArray = new object[array.Length + 1];
        
        for (int i = 0; i < array.Length; i++)
        {
            _innerArray[i] = array[i];
        }

        _innerArray[array.Length] = item;
        
        return _innerArray;
    }
    
    public static object[]? MyInsert(object[] array, int index, object item)
    {
        if (index < 0 || index > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        var newArray = new object[array.Length + 1];
        
        for (int i = 0; i < index; i++)
        {
            newArray[i] = array[i];
        }
        
        newArray[index] = item;

        for (int i = index; i < array.Length; i++)
        {
            newArray[i + 1] = array[i];
        }

        return newArray;
    }
    
    public static int MyIndexOf(object[] array, object item)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }
    
    public static bool MyContains(object[] array, object item)
    {
        if (MyIndexOf(array, item) >= 0) { return true; }

        return false;
    }
    
    public static object[] MyReverse(object[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            left++;
            right--;
        }
        
        return arr;
    }
    
    public static bool MyRemove(object[] arr, object item)
    {
        int index = MyIndexOf(arr, item);
        if (index >= 0)
        {
            MyRemoveAt(arr, index);
            return true;
        }

        return false;
    }
    
    public static void MyRemoveAt(object?[] array, int index)
    {
        if (index < 0 || index > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "out of range");
        }
        
        for (int i = index; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[^1] = default;
    }
}