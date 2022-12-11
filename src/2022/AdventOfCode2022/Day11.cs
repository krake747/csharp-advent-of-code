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
            .Select(_ => StuffSlingingSimianShenanigans(monkeys, w => w / 3L))
            .ToArray();

        return EvaluateMonkeyBusiness(rounds.Last());
    }

    public long Part2(IEnumerable<string> input)
    {
        var monkeys = CreateMonkeys(input).ToList();
        
        // The modulo trick (Modular arithmetic)
        // One needs to guarantee that the divisibility check produces the same result because that check determines
        // the path the items take. One calculates a common multiple divisor x. This keeps the worry numbers
        // small for the divisibility check. Otherwise the worry will keep increasing, leading to an integer overflow.
        //
        // The formula w = w % x achieves this goal.
        //
        // How to find x? One way to find x is to multiply the test divisors together. That way, we obtain a common
        // multiplier that is guaranteed to be divisible by all test values in the data set. In this case all test
        // values are prime numbers, as such the common multiplier is the Least Common Multiple (LCM) 
        //
        // The modulo operator % gives us the remainder of a division, which is always smaller than the divider.
        // By doing w % x, we map every worry to a value between 0 and x - 1, keeping it inside our repeating pattern.
        //
        // For full explanation: https://github.com/blemelin/advent-of-code-2022/blob/main/src/day11.rs
        var x = monkeys.Aggregate(1L, (mod, monkey) => mod * monkey.Test);
        var rounds = Enumerable.Range(1, 10000)
            .Select(_ => StuffSlingingSimianShenanigans(monkeys, w => w % x))
            .ToArray();

        return EvaluateMonkeyBusiness(rounds.Last());
    }

    private static long EvaluateMonkeyBusiness(IEnumerable<long> monkeyInspections)
    {
        return monkeyInspections.OrderDescending()
            .Take(2)
            .Aggregate(1L, (seed, inspection) => seed * inspection);
    }

    private static IEnumerable<long> StuffSlingingSimianShenanigans(IList<Monkey> monkeys, Func<long, long> adjustWorry)
    {
        foreach (var monkey in monkeys)
            while (monkey.Items.Any())
            {
                var worry = monkey.Items.Dequeue();
                monkey.Inspections += 1;
                var newWorry = monkey.Operation(worry);
                var boredWorry = adjustWorry(newWorry);
                var throwToMonkey = boredWorry % monkey.Test == 0
                    ? monkey.IfTrue
                    : monkey.IfFalse;
                monkeys[throwToMonkey].Items.Enqueue(boredWorry);
            }

        return monkeys.Select(m => m.Inspections)
            .ToArray();
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



