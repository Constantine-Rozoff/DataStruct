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
}