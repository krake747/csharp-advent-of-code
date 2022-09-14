using AdventOfCode2021.Shared;
using System.Linq;

namespace AdventOfCode2021;

public static class Day3
{
    /// <summary>
    /// What is the power consumption of the submarine?
    /// </summary> 
    public static int Part1(IEnumerable<string> input)
    {
        var matrix = input.Select(c => c.ToCharArray())
                          .ToArray();

        var (gamma, epsilon) = Enumerable.Range(0, matrix[0].Length)
                                   .Select(c => matrix.GetColumn(c).Count(v => v == '1') >= matrix.Length / 2)
                                   .Aggregate((gamma: "", epsilon: ""), (prev, curr) => curr switch
                                   {
                                       true => (prev.gamma + '1', prev.epsilon + '0'),
                                       false => (prev.gamma + '0', prev.epsilon + '1'),
                                   });

        return Convert.ToInt32(gamma, 2) *  Convert.ToInt32(epsilon, 2);
    }
}
