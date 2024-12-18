﻿using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

[AocPuzzle(2022, 7, "No Space Left On Device")]
public sealed class Day07 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var paths = new Stack<string>();
        var directories = new Dictionary<string, int> { { "/", 0 } };

        foreach (var line in input.Lines)
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

    public static int Part2(AocInput input)
    {
        const int totalDiskSpace = 70000000;
        const int minimumRequiredDiskSpace = 30000000;

        var paths = new Stack<string>();
        var directories = new Dictionary<string, int> { { "/", 0 } };

        foreach (var line in input.Lines)
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

        var unusedDiskSpace = totalDiskSpace - directories["/"];
        var requiredDiskSpace = minimumRequiredDiskSpace - unusedDiskSpace;
        return directories.OrderBy(kvp => kvp.Value)
            .First(kvp => kvp.Value > requiredDiskSpace).Value;
    }
}