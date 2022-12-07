using System.Text.RegularExpressions;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 7, "No Space Left On Device")]
public class Day07 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var paths = new Stack<string>();
        var directories = new Dictionary<string, int>{ {"/", 0} };

        foreach (var line in input)
        {
            var parameters = line.Split(' ');
            if (Regex.IsMatch(line, @"^\$ cd (\w+|/)"))
            {
                paths.Push(string.Concat(paths) + parameters[^1]);
            }
            else if (Regex.IsMatch(line, @"^\$ cd (..)"))
            {
                paths.Pop();
            }
            else if (Regex.IsMatch(line, @"^(\d+)"))
            {
                var size = int.Parse(parameters[0]);
                foreach (var parent in paths)
                {
                    directories[parent] = directories.GetValueOrDefault(parent) + size;
                }
            }
        }
        
        return directories.Where(kvp => kvp.Value < 100000).Sum(kvp => kvp.Value);
    }

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

}