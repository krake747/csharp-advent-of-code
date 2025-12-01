using AdventOfCode.Lib;

namespace AdventOfCode.Y2025;

[AocPuzzle(2025, 1, "Secret Entrance", "C#")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => 
        input.Lines
        | Instructions
        | (instructions => TurnDial(50, instructions))
        | (rotations => rotations.Count(x => x is 0));

    public static int Part2(AocInput input) =>
        input.Lines
        | Pw0X434C49434B
        | (instructions => TurnDial(50, instructions))
        | (rotations => rotations.Count(x => x is 0));

    private static IEnumerable<int> Instructions(IEnumerable<string> lines) =>
        from line in lines
        select Direction(line) * Amount(line);
    
    private static IEnumerable<int> Pw0X434C49434B(IEnumerable<string> lines) =>
        from line in lines
        from _ in Enumerable.Range(0, Amount(line))
        select Direction(line);
    
    private static int Direction(string line) => line[0] == 'L' ? -1 : 1;

    private static int Amount(string line) => int.Parse(line[1..]);
    
    private static IEnumerable<int> TurnDial(int start, IEnumerable<int> instructions)
    {
        var pos = start;
        return instructions.Select(r => pos = (pos + r) % 100);
    }
}