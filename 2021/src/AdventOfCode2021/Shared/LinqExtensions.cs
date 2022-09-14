namespace AdventOfCode2021.Shared;

public static class LinqExtensions
{
    public static IEnumerable<int> RollingSum(this IEnumerable<int> input, int window)
    {
        var numbers = input.ToList();
        var rollingSums = new List<int>();

        if (numbers.Count < window) return new List<int>();

        Enumerable.Range(0, numbers.Count - window + 1)
                  .ToList()
                  .ForEach(n => rollingSums.Add(numbers.Skip(n).Take(window).Sum()));

        return rollingSums;
    }

    public static T[] GetColumn<T>(this T[][] input, int columnNumber) =>
        Enumerable.Range(0, input.GetLength(0))
                  .Select(x => input[x][columnNumber])
                  .ToArray();
    

    public static T[] GetRow<T>(this T[][] input, int rowNumber) => 
        Enumerable.Range(0, input.GetLength(1))
                  .Select(x => input[rowNumber][x])
                  .ToArray();  
}