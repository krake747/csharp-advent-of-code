namespace AdventOfCode2021;

public static class Day8
{
    /// <summary>
    /// In the output values, how many times do digits 1, 4, 7, or 8 appear?
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        var entries = input.Select(s => s.Split(' '))
            .Select(s => new Entry(s[..10].ToList(), s[11..].ToList()));

        var count = entries.SelectMany(e => e.Output)
            .Count(o => new int[] { 2, 4, 3, 7 }.Contains(o.Length));

        return count;
    }

    public static int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    internal record Entry(List<string> Signals, List<string> Output);
}
