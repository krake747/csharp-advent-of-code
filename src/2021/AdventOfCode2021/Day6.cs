namespace AdventOfCode2021;

public static class Day6
{
    public static int Part1(IEnumerable<string> input, int days)
    {
        var lanternFishes = input.SelectMany(i => i.Split(','))
            .Select(int.Parse);

        return CountLanternFishes(lanternFishes.ToList(), days);
    }

    public static long Part2(IEnumerable<string> input, int days)
    {
        var lanternFishes = input.SelectMany(i => i.Split(','))
            .Select(int.Parse);

        return CountLanternFishesDict(lanternFishes.ToList(), days);
    }

    private static int CountLanternFishes(IEnumerable<int> input, int days)
    {
        var fishes = input.ToList();
        for (var day = 0; day < days; day++)
        {
            var newFishes = 0;
            for (var i = 0; i < fishes.Count; i++)
            {
                switch (fishes[i])
                {
                    case 0:
                        fishes[i] = 6;
                        newFishes++;
                        break;
                    default:
                        fishes[i]--;
                        break;
                }
            }

            for (var i = 0; i < newFishes; i++)
            {
                fishes.Add(8);
            }
        }

        return fishes.Count;
    }

    private static long CountLanternFishesDict(IEnumerable<int> input, int days)
    {
        var fishes = new Dictionary<int, long>
        {
            { 0, 0 },
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 },
            { 6, 0 },
            { 7, 0 },
            { 8, 0 }
        };

        foreach (var fish in input.ToList())
        {
            fishes[fish]++;
        }

        for (var day = 0; day < days; day++)
        {
            var reproductionFishes = fishes[0];
            for (var i = 0; i < fishes.Keys.Count - 1; i++)
            {
                fishes[i] = fishes[i + 1];
            }

            fishes[6] = reproductionFishes + fishes[6];
            fishes[8] = reproductionFishes;
        }

        return fishes.Sum(k => k.Value);
    }
}