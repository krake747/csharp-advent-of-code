using AdventOfCodeLib;

namespace AdventOfCode2020;

public class Day05 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        return OrderedPlaneSeatIds(input).Last();
    }

    public int Part2(IEnumerable<string> input)
    {
        var seatIds = OrderedPlaneSeatIds(input);
        return seatIds.Skip(1)
            .Zip(seatIds, (above, below) => (Seat: below + 1, Delta: above - below))
            .Single(seat => seat.Delta == 2).Seat;
    }

    private static int[] OrderedPlaneSeatIds(IEnumerable<string> input)
    {
        return input.Select(boardingPass => string.Concat(boardingPass.Select(ReplaceLetterToBinary)))
            .Select(DecodePlaneSeatId)
            .Order()
            .ToArray();
    }

    private static int DecodePlaneSeatId(string binaryBoardingPass)
    {
        var row = Convert.ToInt32(binaryBoardingPass[..7], 2);
        var col = Convert.ToInt32(binaryBoardingPass[7..], 2);
        return row * 8 + col;
    }
    
    private static char ReplaceLetterToBinary(char c)
    {
        return c switch
        {
            'F' or 'L' => '0',
            _ => '1'
        };
    }
}