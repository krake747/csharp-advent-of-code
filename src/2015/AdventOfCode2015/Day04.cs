using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 4, "The Ideal Stocking Stuffer")]
public sealed class Day04 : IAocDay<int>
{
    private const string PrefixPart1 = "00000";
    private const string PrefixPart2 = "000000";

    public static int Part1(AocInput input) => FindLowestPositiveNumber(input, PrefixPart1);

    public static int Part2(AocInput input) => FindLowestPositiveNumber(input, PrefixPart2);

    private static int FindLowestPositiveNumber(AocInput input, string prefix)
    {
        var queue = new ConcurrentQueue<int>();
        Parallel.ForEach(Enumerable.Range(0, int.MaxValue), MD5.Create, (i, state, md5) =>
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes($"{input.Text}{i}"));
                var hash = string.Join("", bytes.Select(x => x.ToString("x2")));
                if (hash.StartsWith(prefix) is false)
                {
                    return md5;
                }

                queue.Enqueue(i);
                state.Stop();
                return md5;
            },
            _ => { });

        return queue.Min();
    }
}