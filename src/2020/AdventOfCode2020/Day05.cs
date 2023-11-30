using AdventOfCodeLib;

namespace AdventOfCode2020;

public sealed class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input) => OrderedPlaneSeatIds(input.Lines).Last();

    public static int Part2(AocInput input) =>
        OrderedPlaneSeatIds(input.Lines).Chunk(2)
            .Single(seat => seat[1] - seat[0] == 2)
            .First() + 1;

    private static IEnumerable<int> OrderedPlaneSeatIds(IEnumerable<string> input) =>
        input.Select(boardingPass => string.Concat(boardingPass.Select(ReplaceLetterToBinary)))
            .Select(DecodePlaneSeatId)
            .Order();

    private static int DecodePlaneSeatId(string binaryBoardingPass)
    {
        var row = Convert.ToInt32(binaryBoardingPass[..7], 2);
        var col = Convert.ToInt32(binaryBoardingPass[7..], 2);
        return row * 8 + col;
    }

    private static char ReplaceLetterToBinary(char c) =>
        c is 'F' or 'L' ? '0' : '1';
}