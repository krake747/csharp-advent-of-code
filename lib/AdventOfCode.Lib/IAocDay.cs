namespace AdventOfCode.Lib;

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