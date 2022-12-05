namespace AdventOfCodeLib;

public static class LinqExtensions
{
    public static IEnumerable<int> RollingSum(this IEnumerable<int> source, int window)
    {
        var numbers = source.ToList();
        var rollingSums = new List<int>();

        if (numbers.Count < window) return new List<int>();

        Enumerable.Range(0, numbers.Count - window + 1)
            .ToList()
            .ForEach(n => rollingSums.Add(numbers.Skip(n).Take(window).Sum()));

        return rollingSums;
    }

    public static T[] GetColumn<T>(this T[][] source, int columnNumber)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(x => source[x][columnNumber])
            .ToArray();
    }


    public static T[] GetRow<T>(this T[][] source, int rowNumber)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(x => source[rowNumber][x])
            .ToArray();
    }

    public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (item, index));
    }
}