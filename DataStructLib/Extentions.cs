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
    
    public static IEnumerable<T> MySelect<T>(this IEnumerable<T> collection, Func<T, bool> filter = null)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        var results = new List<T>();
        int index = -1;
        
        foreach (var item in collection)
        {
            if (filter != null)
            {
                if (filter(item))
                {
                    results.Add(item);
                }
            }
            else
            {
                results.Add(item);
            }
        }

        return new MySelectEnumerable<T>(results, filter!);
    }
    
    public static IEnumerable<TResult> MySelectMany<TSource, TResult>(
        this IEnumerable<TSource> collection,
        Func<TSource, IEnumerable<TResult>> filter)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (filter == null) throw new ArgumentNullException(nameof(filter));

        var results = new List<TResult>();

        foreach (var item in collection)
        {
            var projectedItems = filter(item);
            if (projectedItems != null)
            {
                results.AddRange(projectedItems);
            }
        }

        return results;
    }
    
    public static bool MyAny<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> filter)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        if (filter == null) throw new ArgumentNullException(nameof(filter));

        foreach (TSource element in collection)
        {
            if (filter(element))
            {
                return true;
            }
        }

        return false;
    }
    
    public static bool MyAll<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> filter)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        if (filter == null) throw new ArgumentNullException(nameof(filter));

        foreach (TSource element in collection)
        {
            if (!filter(element))
            {
                return false;
            }
        }

        return true;
    }
}