using System.Collections;
using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day05 : IDay<IEnumerable<string>, string>
{
    public string Part1(IEnumerable<string> input)
    {
        var (cargoShip, instructions) = SplitCargoShipFromInstructions(input);
        var containerStacks = CreateContainerStacks(cargoShip);
        var rearrangements = CreateRearrangements(instructions);
        var finalStacks = CraneOperatorRearrangesCrates(rearrangements, containerStacks);
        return string.Concat(finalStacks.Select(stack => stack.Value.Peek()));
    }

    public string Part2(IEnumerable<string> input)
    {
        // var m = Regex.Match(line, @"move (.*) from (.*) to (.*)");
        return "1";
    }

    private static (IEnumerable<string> CargoShip, IEnumerable<string> Instructions) SplitCargoShipFromInstructions(
        IEnumerable<string> input)
    {
        var segments = input.ToList();
        var index = segments.IndexOf("");
        var cargoShip = segments.Take(index);
        var instructions = segments.Skip(index + 1);
        return (cargoShip, instructions);
    }

    private static Dictionary<int, Stack<char>> CreateContainerStacks(IEnumerable<string> cargoShip)
    {
        var chunks = cargoShip.Select(stack => stack.Chunk(4))
            .ToArray();

        var crates = chunks.Take(..^1)
            .Select(container => container.Select(cont => cont.Where(c => !new[] { ' ', '[', ']' }.Contains(c))))
            .Reverse()
            .ToArray();

        var stacks = chunks.Last()
            .Select(stack => stack.Where(s => s != ' ').Select(_ => new Stack<char>()))
            .SelectMany(x => x)
            .Reverse()
            .ToArray();

        foreach (var crateRow in crates)
        foreach (var (crate, index) in crateRow.WithIndex())
        {
            var item = crate.SingleOrDefault(' ');
            if (item != ' ') stacks[index].Push(item);
        }

        return Enumerable.Range(1, stacks.Length)
            .ToDictionary(k => k, v => stacks[v - 1]);
    }

    private static IEnumerable<Rearrangement> CreateRearrangements(IEnumerable<string> instructions)
    {
        const string regex = @"move (\d*) from (\d*) to (\d*)";
        return instructions.Select(instruction => Regex.Match(instruction, regex))
            .Select(m => new
            {
                Amount = int.Parse(m.Groups[1].Value),
                From = int.Parse(m.Groups[2].Value),
                To = int.Parse(m.Groups[3].Value),
            })
            .Select(r => new Rearrangement(r.Amount, r.From, r.To));
    }

    private static Dictionary<int, Stack<char>> CraneOperatorRearrangesCrates(
        IEnumerable<Rearrangement> rearrangements,
        IDictionary<int, Stack<char>> containerStacks)
    {
        var finalStacks = new Dictionary<int, Stack<char>>(containerStacks);
        foreach (var move in rearrangements)
        {
            foreach (var _ in Enumerable.Range(1, move.Amount))
            {
                var crate = finalStacks[move.From].Pop();
                finalStacks[move.To].Push(crate);
            }
        }
        
        return finalStacks;
    }

    private readonly record struct Rearrangement(int Amount, int From, int To);
}