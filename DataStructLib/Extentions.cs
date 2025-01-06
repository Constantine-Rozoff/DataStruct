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
    
    public static IEnumerable<T> MySelect<T>(this IEnumerable<T> collection, Func<T, bool> selector)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        var selectCollection = new MySelectEnumerable<T>(collection, selector);

        return selectCollection.Where(selector);
    }
    
    public static IEnumerable<T> MySelectMany<T>(this IEnumerable<IEnumerable<T>> collection, Func<T, bool> selector)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        
        //var selectCollection = new MySelectManyEnumerable<T>(collection, selector);

        return collection.SelectMany(innerCollection => innerCollection.Where(selector));
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
    
    public static T[] MyToArray<T>(this IEnumerable<T> collection)
    {
        List<T> resultList = new List<T>();

        foreach (var item in collection)
        {
            resultList.Add(item);
        }

        return resultList.ToArray(); //TODO: The first elements is missed, cannot find out why
    }
}