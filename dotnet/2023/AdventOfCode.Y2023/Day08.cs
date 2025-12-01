using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2023;

[AocPuzzle(2023, 8, "Haunted Wasteland")]
public sealed partial class Day08 : IAocDay<long>
{
    public static long Part1(AocInput input) =>
        ParseNetwork(input.Lines)
        | (nw => Steps(nw.Nodes, nw.Directions, "AAA", "ZZZ"));


    public static long Part2(AocInput input) =>
        ParseNetwork(input.Lines)
        | (nw => nw.Nodes
            .Where(x => x.Key.EndsWith('A'))
            .Select(x => Steps(nw.Nodes, nw.Directions, x.Key, "Z"))
            .Aggregate(LeastCommonMultiple)
        );

    private static long Steps(Dictionary<string, Node> nodes, string directions, string node, string end)
    {
        var n = node;
        var steps = 0;
        var index = 0;
        while (n.EndsWith(end) is false)
        {
            n = directions[index] is 'L' ? nodes[n].Left : nodes[n].Right;
            index = (index + 1) % directions.Length;
            steps++;
        }

        return steps;
    }

    private static (Dictionary<string, Node> Nodes, string Directions) ParseNetwork(IEnumerable<string> lines)
    {
        var data = lines.ToArray();
        var directions = data[0];
        var nodes = data[2..].Select(ParseNodes).ToDictionary(k => k.Key, v => v.Value);
        return (nodes, directions);
    }

    private static KeyValuePair<string, Node> ParseNodes(string x) =>
        NodesRegex()
            .Match(x)
        | (m => KeyValuePair.Create(m.Groups[1].Value, new Node(m.Groups[2].Value, m.Groups[3].Value)));

    private static long FindLeastCommonMultiple(IEnumerable<long> numbers) =>
        numbers.Aggregate(LeastCommonMultiple);

    private static long LeastCommonMultiple(long x, long y) =>
        Math.Abs(x * y) / GreatestCommonDivisor(x, y);

    private static long GreatestCommonDivisor(long x, long y) =>
        y is 0 ? x : GreatestCommonDivisor(y, x % y);

    [GeneratedRegex(@"(\w+) = \((\w+), (\w+)\)", RegexOptions.Compiled)]
    private static partial Regex NodesRegex();

    private sealed record Node(string Left, string Right);
}