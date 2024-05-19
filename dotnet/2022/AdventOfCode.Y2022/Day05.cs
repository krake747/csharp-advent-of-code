using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

public sealed partial class Day05 : IAocDay<string>
{
    public static string Part1(AocInput input)
    {
        var rearrangementPlan = CreateRearrangementPlan(input.Lines);
        var finalStacks = CargoCraneOperator(CrateMover9000, rearrangementPlan);
        return string.Concat(finalStacks.Select(stack => stack.Peek()));
    }

    public static string Part2(AocInput input)
    {
        var rearrangementPlan = CreateRearrangementPlan(input.Lines);
        var finalStacks = CargoCraneOperator(CrateMover9001, rearrangementPlan);
        return string.Concat(finalStacks.Select(stack => stack.Peek()));
    }

    private static RearrangementPlan CreateRearrangementPlan(IEnumerable<string> input)
    {
        var segments = input.ToList();
        var index = segments.IndexOf("");
        var cargoShip = segments.Take(index);
        var instructions = segments.Skip(index + 1);
        var containerStacks = CreateContainerStacks(cargoShip);
        var rearrangements = CreateRearrangements(instructions);
        return new RearrangementPlan(containerStacks, rearrangements);
    }

    private static readonly char[] Edges = [' ', '[', ']'];

    private static Stack<char>[] CreateContainerStacks(IEnumerable<string> cargoShip)
    {
        var chunks = cargoShip.Select(stack => stack.Chunk(4))
            .ToArray();

        var crates = chunks.Take(..^1)
            .Select(container => container.Select(cont => cont.Where(c => Edges.Contains(c) is false)))
            .Reverse()
            .ToArray();

        var stacks = chunks.Last()
            .SelectMany(stack => stack.Where(s => s != ' ').Select(_ => new Stack<char>()))
            .Reverse()
            .ToArray();

        foreach (var crateRow in crates)
        {
            foreach (var (crate, index) in crateRow.Select((item, index) => (item, index)).ToArray())
            {
                var item = crate.SingleOrDefault(' ');
                if (item != ' ')
                {
                    stacks[index].Push(item);
                }
            }  
        }
        
        return stacks;
    }

    private static IEnumerable<Move> CreateRearrangements(IEnumerable<string> instructions) =>
        instructions
            .Select(instruction => InstructionRegex().Match(instruction))
            .Select(m => new Move
            {
                Amount = int.Parse(m.Groups[1].Value),
                From = int.Parse(m.Groups[2].Value) - 1,
                To = int.Parse(m.Groups[3].Value) - 1
            });

    private static IEnumerable<Stack<char>> CargoCraneOperator(Action<Move, Stack<char>, Stack<char>> crateMover,
        RearrangementPlan rearrangementPlan)
    {
        var (containerStacks, rearrangements) = rearrangementPlan;
        var finalStacks = containerStacks.Select(s => new Stack<char>(s.Reverse())).ToArray();
        foreach (var move in rearrangements.ToArray())
        {
            crateMover(move, finalStacks[move.From], finalStacks[move.To]);
        }

        return finalStacks;
    }

    private static void CrateMover9000(Move move, Stack<char> from, Stack<char> to)
    {
        Enumerable.Range(1, move.Amount)
            .ToList()
            .ForEach(_ => to.Push(from.Pop()));
    }

    private static void CrateMover9001(Move move, Stack<char> from, Stack<char> to)
    {
        var temp = new Stack<char>();
        CrateMover9000(move, from, temp);
        CrateMover9000(move, temp, to);
    }

    private sealed record RearrangementPlan(IEnumerable<Stack<char>> InitialStacks, IEnumerable<Move> Instructions);

    private readonly record struct Move(int Amount, int From, int To);

    [GeneratedRegex(@"move (\d*) from (\d*) to (\d*)")]
    private static partial Regex InstructionRegex();
}