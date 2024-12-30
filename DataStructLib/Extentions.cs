namespace DataStructLib;

public static class Extentions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> filter)
    {
        return new FilterEnumerable<T>(collection, filter);
    }
    
    public static IEnumerable<T> MySkipWhile<T>(this IEnumerable<T> collection, Func<T, bool> filter)
    {
        return new SkipWhileEnumerable<T>(collection, filter);
    }
    
    public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> filter)
    {
        return new TakeWhileEnumerable<T>(collection, filter);
    }
    
    public static T MyFirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> filter = null)
    {
        foreach (var item in collection)
        {
            if (filter != null)
            {
                if (filter(item))
                {
                    return item;
                }
            }
            else
            {
                return item;
            }
        }
        
        return default!;
    }

    public static T MyLastOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> filter = null)
    {
        T lastItem = default!; 
        
        foreach (var item in collection)
        {
            if (filter != null)
            {
                if (filter(item))
                {
                    lastItem = item;
                }
            }
            else
            {
                lastItem = item;
            }
        }

        return lastItem;
    }
}