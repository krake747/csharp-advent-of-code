using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 12, "Hill Climbing Algorithm")]
public sealed class Day12 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var (start, end, map) = CreateMap(input);

        var path = new Queue<Coordinates>();
        path.Enqueue(start);
        while (path.Any())
        {
            var currentCoords = path.Peek();
            var neighborLocations = Coordinates.NeighborLocations(map, currentCoords);
            var x = path.Dequeue();
        }

        return 1;
    }

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static (Coordinates Start, Coordinates End, Location[,] Map) CreateMap(IEnumerable<string> input)
    {
        var locations = input.ToArray();
        var start = new Coordinates(0, 0);
        var end = new Coordinates(0, 0);
        var rows = locations.Length;
        var cols = locations[0].Length;
        var map = new Location[rows, cols];
        for (var row = 0; row < rows; row++)
        for (var col = 0; col < cols; col++)
        {
            var coords = locations[row][col];
            switch (coords)
            {
                case 'S':
                    start = new Coordinates(row, col);
                    break;
                case 'E':
                    end = new Coordinates(row, col);
                    break;
            }

            map[row, col] = Location.Create(coords);
        }

        return (start, end, map);
    }

    private record Location(char Symbol, int Elevation)
    {
        internal static Location Create(char c)
        {
            return new Location(c, ParseElevation(c));
        }

        private static int ParseElevation(char c)
        {
            return c switch
            {
                'S' => ParseElevation('a'),
                'E' => ParseElevation('z'),
                _ => c - 'a'
            };
        }
    }

    private record Coordinates(int Row, int Column)
    {
        internal static IDictionary<Direction, Location> NeighborLocations(Location[,] grid, Coordinates c)
        {
            var neighbors = new[]
            {
                (Direction.Up, c with { Row = c.Row - 1 }),
                (Direction.Down, c with { Row = c.Row + 1 }),
                (Direction.Right, c with { Column = c.Column + 1 }),
                (Direction.Left, c with { Column = c.Column - 1 })
            };

            return (
                from neighbor in neighbors
                where IsOnGrid(grid, neighbor.Item2)
                select new KeyValuePair<Direction, Location>(neighbor.Item1,
                    grid[neighbor.Item2.Row, neighbor.Item2.Column])
            ).ToDictionary(k => k.Key, v => v.Value);
        }

        private static bool IsOnGrid(Location[,] grid, Coordinates c)
        {
            return c.Row >= 0 && c.Row < grid.GetLength(0) && c.Column >= 0 && c.Column < grid.GetLength(1);
        }
    }

    private enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
}



