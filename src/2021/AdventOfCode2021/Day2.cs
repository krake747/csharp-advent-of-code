namespace AdventOfCode2021;

public static class Day2
{
    /// <summary>
    ///     What do you get if you multiply your final horizontal position by your final depth?
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        var (x, y, aim) = input.Select(i => i)
            .Aggregate((x: 0, y: 0, aim: 0), Decode);

        return x * aim;
    }

    /// <summary>
    ///     What do you get if you multiply your final horizontal position by your final depth?
    /// </summary>
    public static int Part2(IEnumerable<string> input)
    {
        var (x, y, aim) = input.Select(i => i)
            .Aggregate((x: 0, y: 0, aim: 0), Decode);

        return x * y;
    }

    private static (int x, int y, int aim) Decode((int x, int y, int aim) coords, string command)
    {
        var direction = command.Split(' ')[0];
        var units = int.Parse(command.Split(' ')[1]);
        return direction switch
        {
            "forward" => (coords.x + units, coords.y + coords.aim * units, coords.aim),
            "down" => (coords.x, coords.y, coords.aim + units),
            "up" => (coords.x, coords.y, coords.aim - units),
            _ => (coords.x, coords.y, coords.aim)
        };
    }
}