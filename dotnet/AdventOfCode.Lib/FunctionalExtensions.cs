namespace AdventOfCode.Lib;

public static class FunctionalPipeExtensions
{
    extension<T, TResult>(T)
    {
        public static TResult operator |(T source, Func<T, TResult> func) => func(source);
    }
}

public static class FunctionalCurryExtensions
{
    extension<T1, T2, T3>(Func<T1, T2, T3> source)
    {
        public Func<T1, Func<T2, T3>> Curry()
        {
            return t1 => t2 => source(t1, t2);
        }

        public Func<T2, T3> Partial(T1 t1)
        {
            return t2 => source(t1, t2);
        }
    }
}