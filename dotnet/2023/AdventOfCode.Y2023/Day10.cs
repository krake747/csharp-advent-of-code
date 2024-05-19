using System.Numerics;
using AdventOfCode.Lib;
using static AdventOfCode.Y2023.Day10;

namespace AdventOfCode.Y2023;

using Pipes = Dictionary<Pipe, char>;
using Loop = HashSet<Pipe>;

[AocPuzzle(2023, 10, "Pipe Maze")]
public sealed class Day10 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        ParsePipes(input.Lines)
            .Pipe(LoopPipeNetwork)
            .Pipe(StepsStartToFarthest);

    public static int Part2(AocInput input) => 0;

    private static Pipes ParsePipes(IEnumerable<string> lines)
    {
        var pipeLayout = lines.ToArray();
        var rows = pipeLayout.Length;
        var cols = pipeLayout[0].Length;
        var pipes = new Pipes();
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                pipes.Add(new Pipe(col, row), pipeLayout[row][col]);
            }
        }

        return pipes;
    }

    private static Loop LoopPipeNetwork(Pipes pipes)
    {
        var loop = new Loop();
        var pipe = pipes.Keys.Single(k => pipes[k] is 'S');
        var direction = Pipe.Directions.First(dir => Inlet(pipes[pipe + dir]).Contains(-dir));
        while (loop.Contains(pipe) is false)
        {
            loop.Add(pipe);
            pipe += direction;
            if (pipes[pipe] is 'S')
            {
                break;
            }

            direction = Outlets(pipes[pipe]).Single(outlet => outlet != -direction);
        }

        return loop;
    }

    private static int StepsStartToFarthest(Loop loop) =>
        loop.Count / 2;

    private static IEnumerable<Pipe> Inlet(char pipe) =>
        Outlets(pipe).Select(p => p);

    private static IEnumerable<Pipe> Outlets(char pipe) => pipe switch
    {
        'F' => [Pipe.South, Pipe.East],
        '7' => [Pipe.West, Pipe.South],
        'J' => [Pipe.North, Pipe.West],
        'L' => [Pipe.North, Pipe.East],
        '|' => [Pipe.North, Pipe.South],
        '-' => [Pipe.West, Pipe.East],
        'S' => [Pipe.North, Pipe.South, Pipe.West, Pipe.East],
        _ => [] // '.'
    };

    internal readonly record struct Pipe(int X, int Y)
        : IAdditionOperators<Pipe, Pipe, Pipe>, ISubtractionOperators<Pipe, Pipe, Pipe>,
            IUnaryNegationOperators<Pipe, Pipe>
    {
        public static readonly Pipe North = new(0, -1); // Go 1 row up:    x y -> x y-1
        public static readonly Pipe South = new(0, 1); // Go 1 row down:  x y -> x y+1
        public static readonly Pipe West = new(-1, 0); // Go 1 col left:  x y -> x-1 y
        public static readonly Pipe East = new(1, 0); // Go 1 col right: x y -> x+1 y
        public static readonly Pipe[] Directions = [North, South, West, East];

        public static Pipe operator +(Pipe left, Pipe right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static Pipe operator -(Pipe left, Pipe right) =>
            new(left.X - right.X, left.Y - right.Y);

        public static Pipe operator -(Pipe value) =>
            new(-value.X, -value.Y);
    }
}