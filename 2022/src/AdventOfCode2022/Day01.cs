using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day01 : IDay
{
    public int Part1(IEnumerable<string> input)
    {
        return CreateElves(input)
            .Max();
    }
    
    public int Part2(IEnumerable<string> input)
    {
        return CreateElves(input)
            .OrderDescending()
            .Take(3)
            .Sum();
    }
    
    private static IEnumerable<int> CreateElves(IEnumerable<string> calories)
    {
        return string.Join("|", calories)
            .Split("||")
            .Select(elf => elf.Split("|")
                .Select(int.Parse)
                .Sum());
    }
}