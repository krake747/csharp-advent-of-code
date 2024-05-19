namespace AdventOfCode.Y2021;

public static class Day8
{
    /// <summary>
    ///     In the output values, how many times do digits 1, 4, 7, or 8 appear?
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        var entries = input.Select(s => s.Split(' '))
            .Select(s => new Entry(s[..10].ToList(), s[11..].ToList()));

        var count = entries.SelectMany(e => e.Output)
            .Count(d => d.Length is 2 or 3 or 4 or 7);

        return count;
    }

    public static int Part2(IEnumerable<string> input)
    {
        var entries = input.Select(s => s.Split(' '))
            .Select(s => new Entry(s[..10].ToList(), s[11..].ToList()));

        return entries.Sum(e => CalculateOutput(ParseCodes(e.Input), e.Output));
    }

    private static Dictionary<string, string> ParseCodes(IEnumerable<string> codesStream)
    {
        // acedgfb -> 8
        // cdfbe   -> 2, 3, 5? 
        // gcdfa   -> 2, 3, 5? 
        // fbcad   -> 2, 3, 5? 
        // dab     -> 7
        // cefabd  -> 0, 6, 9? cef{7:abd} -> c{4:ef} -> 9
        // cdfgeb  -> 0, 6? 6 (does not contain char a which is present in one)
        // eafb    -> 4
        // cagedb  -> 0? 0 (remaing of length 6)
        // ab      -> 1

        var codes = codesStream.ToArray();

        // 4 unique codes 1, 4, 7, 8 are determined by their length.
        var one = codes.Single(c => c.Length == 2);
        var four = codes.Single(c => c.Length == 4);
        var seven = codes.Single(c => c.Length == 3);
        var eight = codes.Single(c => c.Length == 7);

        // 9 is determined by length of 6 and the one line which is not present in 'seven' and 'four'.
        var nine = codes.Single(c =>
            c.Length == 6 &&
            c.Except(seven).Except(four).Count() == 1);

        // 6 is determined by length of 6 and not equal to 'nine' and 1 line present in 'one'.
        var six = codes.Single(c =>
            c.Length == 6 &&
            c != nine &&
            one.Except(c).Count() == 1);

        // 0 is determined by length of 6 and not equal to 'nine' and not equal to 'six'.
        var zero = codes.Single(c =>
            c.Length == 6 &&
            c != nine &&
            c != six);

        // Determine single lines
        //  aaaa
        // b    c
        // b    c
        //  dddd
        // e    f
        // e    f
        //  gggg
        var e = eight.Except(nine).Single();
        var c = eight.Except(six).Single();
        var d = eight.Except(zero).Single();
        var f = one.Except(new[] { c }).Single();

        // 5 is determined by length of 5 and does not contains line 'c' and line 'e'.
        var five = codes.Single(s =>
            s.Length == 5 &&
            !s.Contains(c) &&
            !s.Contains(e));

        // 2 is determined by length of 5, not equal to 'five', contains 'c' and  line 'e', but not line 'f'.
        var two = codes.Single(s =>
            s.Length == 5 &&
            s != five &&
            s.Contains(c) &&
            s.Contains(e) &&
            !s.Contains(f));

        // three is determined by length of 5, not equal to 'five' and 'two'
        var three = codes.Single(s =>
            s.Length == 5 &&
            s != five &&
            s != two);

        return new Dictionary<string, string>
        {
            { string.Concat(zero.OrderBy(c => c)), "0" },
            { string.Concat(one.OrderBy(c => c)), "1" },
            { string.Concat(two.OrderBy(c => c)), "2" },
            { string.Concat(three.OrderBy(c => c)), "3" },
            { string.Concat(four.OrderBy(c => c)), "4" },
            { string.Concat(five.OrderBy(c => c)), "5" },
            { string.Concat(six.OrderBy(c => c)), "6" },
            { string.Concat(seven.OrderBy(c => c)), "7" },
            { string.Concat(eight.OrderBy(c => c)), "8" },
            { string.Concat(nine.OrderBy(c => c)), "9" }
        };
    }

    private static int CalculateOutput(Dictionary<string, string> mappings, IEnumerable<string> codes)
    {
        return int.Parse(string.Concat(codes.Select(c => mappings[string.Concat(c.OrderBy(c => c))])));
    }

    private sealed record Entry(List<string> Input, List<string> Output);
}