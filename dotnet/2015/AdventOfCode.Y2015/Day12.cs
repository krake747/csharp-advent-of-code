using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2015;

[AocPuzzle(2015, 12, "JSAbacusFramework.io")]
public sealed partial class Day12 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        SignedIntegersRegex()
            .Matches(input.Text)
            .Aggregate(0, (seed, match) => seed + int.Parse(match.Value));

    public static int Part2(AocInput input) => ParseNodes(JsonNode.Parse(input.Text)!);

    private static int ParseNodes(JsonNode node)
    {
        return node switch
        {
            JsonValue value => value.TryGetValue<int>(out var number) ? number : 0,
            JsonArray array => array.Sum(ParseNodes!),
            JsonObject obj => Red(obj) ? 0 : obj.Select(x => x.Value).Sum(ParseNodes!),
            _ => throw new ArgumentOutOfRangeException(nameof(node), node, null)
        };
    }

    private static bool Red(JsonObject node) =>
        node.Select(x => x.Value)
            .OfType<JsonValue>()
            .Any(x => x.ToString() is "red");

    [GeneratedRegex("([-0-9]+)")]
    private static partial Regex SignedIntegersRegex();
}