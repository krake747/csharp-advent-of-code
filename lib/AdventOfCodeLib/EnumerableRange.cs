namespace AdventOfCodeLib;

public static class EnumerableRange
{
    public static IEnumerable<int> Integer(int from, int to, int step)
    {
        if (step <= 0)
        {
            step = step == 0 ? 1 : -step;
        }

        if (from <= to)
        {
            for (var i = from; i <= to; i += step)
            {
                yield return i;
            }
        }
        else
        {
            for (var i = from; i >= to; i -= step)
            {
                yield return i;
            }
        }
    }
}