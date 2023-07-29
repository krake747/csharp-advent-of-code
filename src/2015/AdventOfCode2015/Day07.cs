using AdventOfCodeLib;

namespace AdventOfCode2015;
#pragma warning disable CS8602

[AocPuzzle(2015, 7, "Some Assembly Required")]
public sealed class Day07 : IAocDay<ushort>
{
    public static ushort Part1(AocInput input)
    {
        var instructions = ParseInstructions(input.Lines);
        return EvaluateWire("a");

        ushort EvaluateWire(string wire)
        {
            var instruction = instructions[wire];
            var signal = instruction switch
            {
                [_, "->", ..] => Assign(instruction),
                [_, "AND", ..] => And(instruction),
                [_, "OR", ..] => Or(instruction),
                [_, "LSHIFT", ..] => LShift(instruction),
                [_, "RSHIFT", ..] => RShift(instruction),
                ["NOT", ..] => Not(instruction),
                _ => throw new ArgumentException("Undefined Operation")
            };

            instructions[wire] = new[] { signal.ToString(), "->", wire };
            return signal;

            ushort Evaluate(string x) => char.IsLetter(x[0]) ? EvaluateWire(x) : ushort.Parse(x);
            ushort Assign(IReadOnlyList<string> x) => Evaluate(x[0]);
            ushort And(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) & Evaluate(x[2]));
            ushort Or(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) | Evaluate(x[2]));
            ushort LShift(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) << Evaluate(x[2]));
            ushort RShift(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) >> Evaluate(x[2]));
            ushort Not(IReadOnlyList<string> x) => (ushort)~Evaluate(x[1]);
        }
    }

    public static ushort Part2(AocInput input)
    {
        var a = Part1(input);
        var instructions = ParseInstructions(input.Lines);
        instructions["b"] = new[] { $"{a}", "->", "b" };
        return EvaluateWire("a");

        ushort EvaluateWire(string wire)
        {
            var instruction = instructions[wire];
            var signal = instruction switch
            {
                [_, "->", ..] => Assign(instruction),
                [_, "AND", ..] => And(instruction),
                [_, "OR", ..] => Or(instruction),
                [_, "LSHIFT", ..] => LShift(instruction),
                [_, "RSHIFT", ..] => RShift(instruction),
                ["NOT", ..] => Not(instruction),
                _ => throw new ArgumentException("Undefined Operation")
            };

            instructions[wire] = new[] { signal.ToString(), "->", wire };
            return signal;

            ushort Evaluate(string x) => char.IsLetter(x[0]) ? EvaluateWire(x) : ushort.Parse(x);
            ushort Assign(IReadOnlyList<string> x) => Evaluate(x[0]);
            ushort And(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) & Evaluate(x[2]));
            ushort Or(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) | Evaluate(x[2]));
            ushort LShift(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) << Evaluate(x[2]));
            ushort RShift(IReadOnlyList<string> x) => (ushort)(Evaluate(x[0]) >> Evaluate(x[2]));
            ushort Not(IReadOnlyList<string> x) => (ushort)~Evaluate(x[1]);
        }
    }

    private static IDictionary<string, string[]> ParseInstructions(IEnumerable<string> input) =>
        input.Select(x => x.Split(' '))
            .OrderBy(x => x[^1])
            .ToDictionary(k => k[^1]);
}
#pragma warning restore CS8602