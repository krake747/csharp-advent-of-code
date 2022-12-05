namespace AdventOfCodeLib;

public interface IDay<in T, out TResult>
{
    public TResult Part1(T input);
    public TResult Part2(T input);
}