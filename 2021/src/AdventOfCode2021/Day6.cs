using AdventOfCode2021.Shared;

namespace AdventOfCode2021;

public static class Day6
{
    public static int Part1(IEnumerable<string> input, int days = 80)
    {
        var timers = input.SelectMany(i => i.Split(','))
            .Select(int.Parse)
            .ToList();

        var state = timers.ToList();
        for (var day = 1; day < days + 1; day++)
        {
            if (day > 1)
            {
                if (state.Count(t => t == 0) > 0)
                {
                    foreach (var (t, i) in state.ToList().WithIndex())
                    {
                        if (t == 0)
                        {
                            state.Add(9);
                        }
                    } 
                }

                foreach (var (t, i) in state.ToList().WithIndex())
                {
                    if (t == 0)
                    {
                        state[i] = 7;
                    }
                }
            }
          
            state = state.Where(t => t != 0).Select(t => t -= 1).ToList();
        }

        
        return state.Count();
    }

    public static int Part2(IEnumerable<string> input)
    {
        return 1;
    }
}
