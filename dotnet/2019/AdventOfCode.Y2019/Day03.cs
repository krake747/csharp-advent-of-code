using AdventOfCode.Lib;

namespace AdventOfCode.Y2019;

[AocPuzzle(2019, 3, "Crossed Wires")]
public sealed class Day03 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var wire1 = Trace(input.AllLines[0]);
        var wire2 = Trace(input.AllLines[1]);
        return wire1.Keys.Where(p => wire2.ContainsKey(p)).Min(p => Math.Abs(p.Irow) + Math.Abs(p.Icol));
    }

    public static int Part2(AocInput input)
    {
        var wire1 = Trace(input.AllLines[0]);
        var wire2 = Trace(input.AllLines[1]);
        return wire1.Keys.Where(p => wire2.ContainsKey(p)).Min(p => wire1[p] + wire2[p]);
    }


    private static Dictionary<Position, int> Trace(string path)
    {
        Dictionary<Position, int> positions = [];
        var position = new Position(0, 0);
        var distance = 0;
        var steps = path.Split(',');
        foreach (var step in steps)
        {
            if (step is not [var command, .. var len])
            {
                continue;
            }

            for (var i = 0; i < int.Parse(len); i++)
            {
                position = Position.Move(position, command);
                distance++;
                if (positions.TryGetValue(position, out _) is false)
                {
                    positions[position] = distance;
                }
            }
        }

        return positions;
    }

    private readonly record struct Position(int Irow, int Icol)
    {
        public static Position Move(Position position, char command)
        {
            return command switch
            {
                'U' => position with { Irow = position.Irow - 1 },
                'D' => position with { Irow = position.Irow + 1 },
                'R' => position with { Icol = position.Icol + 1 },
                'L' => position with { Icol = position.Icol - 1 },
                _ => throw new ArgumentException("Unknown Command")
            };
        }
    }
}