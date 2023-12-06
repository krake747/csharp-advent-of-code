namespace AdventOfCodeLib;

public interface IAocDayTest<in TResult>
{
    void Part1(AocInput input, TResult expected);
    void Part2(AocInput input, TResult expected);
}

public interface IAocDayTest<in TResult1, in TResult2>
{
    void Part1(AocInput input, TResult1 expected);
    void Part2(AocInput input, TResult2 expected);
}