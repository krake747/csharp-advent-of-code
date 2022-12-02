namespace AdventOfCodeLib;

public interface IDay<in T>
{
    public int Part1(T input);
    public int Part2(T input);
}