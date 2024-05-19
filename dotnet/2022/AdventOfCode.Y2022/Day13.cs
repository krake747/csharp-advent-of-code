using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

[AocPuzzle(2022, 13, "Distress Signal")]
public sealed class Day13 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        return PacketNodes(input.Lines).Chunk(2)
            .Select((pair, idx) => (Index: idx + 1, Order: ComparePackets(pair[0], pair[^1])))
            .Where(packets => packets.Order < 0)
            .Sum(packets => packets.Index);
    }

    public static int Part2(AocInput input)
    {
        var dividers = PacketNodes(new[] { "[[2]]", "[[6]]" }).ToImmutableList();
        var packets = PacketNodes(input.Lines).Concat(dividers).ToImmutableList();
        return packets.Sort(ComparePackets)
            .Select((packet, idx) => (Index: idx + 1, Packet: packet))
            .Where(p => dividers.Contains(p.Packet))
            .Aggregate(1, (seed, p) => seed * p.Index);
    }

    private static int ComparePackets(JsonNode? left, JsonNode? right)
    {
        return (left, right) switch
        {
            (JsonValue lhs, JsonValue rhs) => lhs.GetValue<int>().CompareTo((int)rhs),
            (JsonValue lhs, JsonArray rhs) => ComparePackets(new JsonArray((int)lhs), rhs),
            (JsonArray lhs, JsonValue rhs) => ComparePackets(lhs, new JsonArray((int)rhs)),
            (JsonArray lhs, JsonArray rhs) => lhs.Zip(rhs, ComparePackets)
                .FirstOrDefault(v => v != 0, lhs.Count - rhs.Count),
            _ => throw new ArgumentOutOfRangeException($"{left}, {right}")
        };
    }

    // C# code snippet 1: This was inspired by a post on the r/adventofcode subreddit.
    // It uses System.Text.Json.Nodes which was introduced in .NET 6
    private static IEnumerable<JsonNode?> PacketNodes(IEnumerable<string> input)
    {
        return input.Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(packets => JsonNode.Parse(packets));
    }

    // C# code snippet 2: This was inspired by a post on the r/adventofcode subreddit. It uses System.Text.Json.
    // The version above is preferred since it uses JsonNode instead of custom objects.
    private static IEnumerable<Packet> PacketPairs(IEnumerable<string> input)
    {
        return input.Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(Packet.Parse);
    }

    private abstract record Packet
    {
        internal static Packet Parse(string value) => Parse(JsonSerializer.Deserialize<JsonElement>(value));

        private static Packet Parse(JsonElement element) =>
            element.ValueKind == JsonValueKind.Number
                ? new IntPacket(element.GetInt32())
                : new Packets(element.EnumerateArray().Select(Parse).ToArray());
    }

    private record IntPacket(int Value) : Packet;

    private record Packets(Packet[] Values) : Packet;
}