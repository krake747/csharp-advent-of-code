using AdventOfCode2021.Shared;

namespace AdventOfCode2021;

public static class Day2
{
    /// <summary>
    /// What do you get if you multiply your final horizontal position by your final depth?
    /// </summary>
    public static int Part1(IEnumerable<string> input, int x, int y)
    {
        var commands = input.Select(Decode)
                            .Prepend(new Coordinate(x, y));

        var sumX = commands.Sum(loc => loc.X);
        var sumY = commands.Sum(loc => loc.Y);

        return sumX * sumY;
    }

    private static Coordinate Decode(string command)
    {
        var instruction = new Instruction(command.Split(' ')[0], int.Parse(command.Split(' ')[1]));
        return instruction.Direction switch
        {
            "forward" => new Coordinate(instruction.Units, 0),
            "down" => new Coordinate(0, instruction.Units),
            "up" => new Coordinate(0, -instruction.Units),
            _ => new Coordinate(0, 0)
        };
    }

    private record Coordinate(int X, int Y);
    private record Instruction(string Direction, int Units);
}
