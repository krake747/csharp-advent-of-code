namespace AdventOfCodeLib;

public interface IAocDay<out TResult>
{
    static abstract TResult Part1(AocInput input);
    static abstract TResult Part2(AocInput input);
}

public interface IAocDay<out TResult1, out TResult2>
{
    static abstract TResult1 Part1(AocInput input);
    static abstract TResult2 Part2(AocInput input);
}

public interface IAocTestDay<in TResult>
{
    void Part1(AocInput input, TResult expected);
    void Part2(AocInput input, TResult expected);
}

public interface IAocTestDay<in TResult1, in TResult2>
{
    void Part1(AocInput input, TResult1 expected);
    void Part2(AocInput input, TResult2 expected);
}