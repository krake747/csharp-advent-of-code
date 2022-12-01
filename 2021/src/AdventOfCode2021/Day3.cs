using AdventOfCodeLib;

namespace AdventOfCode2021;

public static class Day3
{
    /// <summary>
    ///     What is the power consumption of the submarine?
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        var diagnostics = input.Select(c => c.ToCharArray())
            .ToArray();

        var (gam, eps) = Enumerable.Range(0, diagnostics[0].Length)
            .Select(c => diagnostics.GetColumn(c).Count(v => v == '1') >= diagnostics.Length / 2.0)
            .Aggregate((gam: "", eps: ""), (prev, curr) => curr switch
            {
                true => (prev.gam + '1', prev.eps + '0'),
                false => (prev.gam + '0', prev.eps + '1')
            });

        var gamma = Convert.ToInt32(gam, 2);
        var epsilon = Convert.ToInt32(eps, 2);

        return gamma * epsilon;
    }

    /// <summary>
    ///     What is the life support rating of the submarine?
    /// </summary>
    public static int Part2(IEnumerable<string> input)
    {
        var values = input.ToList();
        var oxy = values.ToList();

        for (var i = 0; oxy.Count != 1; i++)
        {
            var ones = oxy.Count(s => s[i] == '1');
            if (ones >= oxy.Count / 2.0)
                oxy.RemoveAll(s => s[i] == '0');
            else
                oxy.RemoveAll(s => s[i] == '1');
        }

        var oxygen = Convert.ToInt32(oxy[0], 2);

        var co2 = values.ToList();

        for (var i = 0; co2.Count != 1; i++)
        {
            var zeroes = co2.Count(s => s[i] == '0');
            if (zeroes > co2.Count / 2.0)
                co2.RemoveAll(s => s[i] == '0');
            else
                co2.RemoveAll(s => s[i] == '1');
        }

        var carbonDioxide = Convert.ToInt32(co2[0], 2);

        return oxygen * carbonDioxide;
    }
}