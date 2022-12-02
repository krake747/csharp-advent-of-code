namespace AdventOfCodeLib;

public interface IDayEnumerable
{
    public int Part1(IEnumerable<string> input);
    public int Part2(IEnumerable<string> input);
}

public interface IDayString
{
    public int Part1(string input);
    public int Part2(string input);
}