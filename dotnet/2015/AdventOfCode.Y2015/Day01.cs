using AdventOfCode.Lib;

namespace AdventOfCode.Y2015;

[AocPuzzle(2015, 1, "Not Quite Lisp")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text.Sum(GoUpOrDownOneFloor);

    public static int Part2(AocInput input) => input.Text
        .Select(GoUpOrDownOneFloor)
        .Aggregate(new List<int>(), (floors, floor) =>
        {
            var lastFloorLevel = floors.Count > 0 ? floors[^1] : 0;
            var updatedFloor = lastFloorLevel + floor;
            floors.Add(updatedFloor);
            return floors;
        })
        .IndexOf(-1) + 1;

    private static int GoUpOrDownOneFloor(char x) => x is '(' ? 1 : -1;
}