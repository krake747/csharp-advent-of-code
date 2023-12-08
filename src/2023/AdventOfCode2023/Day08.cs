using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 8, "Haunted Wasteland")]
public sealed partial class Day08 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var (instructions, nodes) = ParseNetwork(input.Lines);
        var current = nodes.First(x => x.Key == "AAA");
        var i = 0;
        var steps = 0;
        while (current.Key is not "ZZZ")
        {
            current = nodes.First(x => x.Key == (instructions[i] is 'L' ? current.Value.Left : current.Value.Right));
            
            i++;
            if (i == instructions.Length)
            {
                i = 0;
            }

            steps++;
        }

        return steps;
    }

    public static int Part2(AocInput input) => 0;

    private static (string, Dictionary<string, Node>) ParseNetwork(IEnumerable<string> lines)
    {
        var data = lines.ToArray();
        var instructions = data[0];
        var nodes = data[2..].Select(ParseNodes).ToDictionary();
        return (instructions, nodes);
    }

    private static KeyValuePair<string, Node> ParseNodes(string x) =>
        NodesRegex()
            .Match(x)
            .Pipe(m => KeyValuePair.Create(m.Groups[1].Value, new Node(m.Groups[2].Value, m.Groups[3].Value)));

    [GeneratedRegex(@"(\w+) = \((\w+), (\w+)\)", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex NodesRegex();

    private sealed record Node(string Left, string Right);
}