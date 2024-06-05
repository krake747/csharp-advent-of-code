namespace AdventOfCode.Lib;

public static class FunctionalExtensions
{
    public static TOut Pipe<TIn, TOut>(this TIn source, Func<TIn, TOut> func) => func(source);
    
    public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> source)
    {
        return t1 => t2 => source(t1, t2);
    }
    
    public static Func<T2, TOut> Partial<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1)
    {
        return t2 => func(t1, t2);
    }
}