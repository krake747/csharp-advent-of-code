using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 11, "Monkey in the Middle")]
public partial class Day11 : IDay<IEnumerable<string>, long>
{
    public long Part1(IEnumerable<string> input)
    {
        var monkeys = CreateMonkeys(input).ToList();
        var rounds = Enumerable.Range(1, 20)
            .Select(round => StuffSlingingSimianShenanigans(monkeys, 3))
            .ToList();
        
        return rounds.Last()
            .OrderByDescending(kvp => kvp.Value)
            .Take(2)
            .Aggregate(1L, (seed, inspections) => seed * inspections.Value);
    }

    public long Part2(IEnumerable<string> input)
    {
        var monkeys = CreateMonkeys(input).ToList();
        var rounds = Enumerable.Range(1, 10000)
            .Select(round => StuffSlingingSimianShenanigans(monkeys, 3))
            .ToList();

        // var rounds = new List<IDictionary<int, long>>();
        // foreach (var round in Enumerable.Range(1, 10000))
        // {
        //     var end = StuffSlingingSimianShenanigansNoWorry(monkeys);
        //     rounds.Add(end);
        // }
        
        return rounds.Last()
            .OrderByDescending(kvp => kvp.Value)
            .Take(2)
            .Aggregate(1L, (seed, inspections) => seed * inspections.Value);
    }

    private static IDictionary<int, long> StuffSlingingSimianShenanigans(List<Monkey> monkeys, long worryFactor)
    {
        foreach (var monkey in monkeys)
        {
            var initialQueueCount = monkey.Items.Count;
            for (var i = 0; i < initialQueueCount; i++)
            {
                var worry = monkey.Items.Dequeue();
                monkey.Inspections += 1;
                var newWorry = monkey.Operation(worry);
                var boredWorry = newWorry / worryFactor;
                var throwToMonkey = boredWorry % monkey.Test == 0
                    ? monkey.IfTrue
                    : monkey.IfFalse;
                monkeys[throwToMonkey].Items.Enqueue(boredWorry);
            }
        }

        return monkeys.ToDictionary(k => k.Id, v => v.Inspections);
    }

    
    private static IEnumerable<Monkey> CreateMonkeys(IEnumerable<string> input)
    {
        var monkeys = input.Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Trim())
            .ToArray();

        var countMonkeys = monkeys.Count(m => m.StartsWith("Monkey"));
        return monkeys.Chunk(monkeys.Length / countMonkeys)
            .Select(ParseMonkeyAttributes)
            .Select(Monkey.Create);
    }

    private static IEnumerable<string> ParseMonkeyAttributes(IEnumerable<string> attributes)
    {
        return attributes.Select(attribute => attribute.Split(':') switch
        {
            [var id, ""] => MatchNumber(id),
            ["Starting items", var items] => items.Trim(),
            ["Operation", var operation] => operation.Trim(),
            ["Test", var divisible] => MatchNumber(divisible),
            ["If true", var id] => MatchNumber(id),
            ["If false", var id] => MatchNumber(id),
            _ => throw new UnreachableException($"Can't match {attribute}")
        });

        string MatchNumber(string id)
        {
            var m = RegexNumber().Match(id);
            return m.Success
                ? m.Groups[1].ToString()
                : throw new ArgumentException($"Can't match Id in {id}");
        }
    }

    [GeneratedRegex(@"(\d+)")]
    private static partial Regex RegexNumber();

    private class Monkey
    {
        public required int Id { get; init; }
        public required Queue<long> Items { get; init; }
        public required Func<long, long> Operation { get; init; }
        public required int Test { get; init; }
        public required int IfTrue { get; init; }
        public required int IfFalse { get; init; }
        public long Inspections { get; set; }

        internal static Monkey Create(IEnumerable<string> attributes)
        {
            var data = attributes.ToArray();
            var items = data[1].Split(',', ' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
            return new Monkey
            {
                Id = int.Parse(data[0]),
                Items = new Queue<long>(items),
                Operation = ArithmeticOperation(data[2]),
                Test = int.Parse(data[3]),
                IfTrue = int.Parse(data[4]),
                IfFalse = int.Parse(data[5])
            };

            Func<long, long> ArithmeticOperation(string operation)
            {
                return operation.Split(' ') switch
                {
                    [.., "*", "old"] => old => old * old,
                    [.., "*", var value] => old => old * long.Parse(value),
                    [.., "+", "old"] => old => old + old,
                    [.., "+", var value] => old => old + long.Parse(value),
                    _ => throw new UnreachableException($"Can't match {operation}")
                };
            }
        }
    }
}



