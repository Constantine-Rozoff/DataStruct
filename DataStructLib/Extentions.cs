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
    
    public static IEnumerable<T> MyFirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> filter)
    {
        return new FirstOrDefaultEnumerable<T>(collection, filter);
    }
}