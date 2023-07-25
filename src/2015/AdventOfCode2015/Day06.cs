using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 6, "Probably a Fire Hazard")]
public sealed class Day06 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var instructions = ParseInstructions(input.Lines);
        var grid = MakeGrid();

        foreach (var (command, fromPoint, toPoint) in instructions)
        {
            for (var i = fromPoint.X; i < toPoint.X + 1; i++)
            for (var j = fromPoint.Y; j < toPoint.Y + 1; j++)
            {
                grid[new Point(i, j)] = command switch
                {
                    Command.On => true,
                    Command.Off => false,
                    Command.Toggle => !grid[new Point(i, j)],
                    _ => throw new ArgumentOutOfRangeException(nameof(command), command.ToString())
                };
            }
        }
        
        return grid.Values.Count(x => x);
    } 

    public static int Part2(AocInput input) => 0;

    private static IEnumerable<Instruction> ParseInstructions(IEnumerable<string> lines)
    {
        return lines.Select(line => line.Split(' ') switch
        {
            [var turn, var onOrOff, var from, _, var to] => new Instruction(ConvertToCommand($"{turn} {onOrOff}"), 
                Point.Create(from), Point.Create(to)),
            [var toggle, var from, _, var to] => new Instruction(ConvertToCommand(toggle), 
                Point.Create(from), Point.Create(to)),
            _ => throw new ArgumentException("Pattern not defined")
        });

        Command ConvertToCommand(string c) => c switch
        {
            "turn on" => Command.On,
            "turn off" => Command.Off,
            "toggle" => Command.Toggle,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c)
        };
    }

    private static Dictionary<Point, bool> MakeGrid()
    {
        var grid = new Dictionary<Point, bool>();
        for (var i = 0; i < 1000; i++)
        for (var j = 0; j < 1000; j++)
        {
            grid.Add(new Point(i, j), false);
        }

        return grid;
    }

    private sealed record Instruction(Command Command, Point FromPoint, Point ToPoint);

    private readonly record struct Point(int X, int Y)
    {
        internal static Point Create(string s)
        {
            var point = s.Split(',').Select(int.Parse).ToArray();
            return new Point(point[0], point[1]);
        }
    }

    private enum Command
    {
        On,
        Off,
        Toggle
    }
}