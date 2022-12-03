using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day03 : IDay<IEnumerable<string>>
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public Day03()
    {
    }

    
    public int Part1(IEnumerable<string> input)
    {
        var priorities = CreatePriorities(Alphabet);
        return input.Select(CreateTwoCompartments)
            .Select(DistinctItemFromBothCompartments)
            .Sum(item => priorities[item]);
    }



    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static Dictionary<char, int> CreatePriorities(string alphabet)
    {
        return Enumerable.Range(0, alphabet.Length)
            .Select((c, i) => (Priority: i + 1, Item: alphabet[c]))
            .ToDictionary(k => k.Item, v => v.Priority);
    }

    private static Compartment CreateTwoCompartments(string backpack)
    {
        return new Compartment(backpack[..(backpack.Length / 2)], backpack[(backpack.Length / 2)..]);
    }
    
    private static char DistinctItemFromBothCompartments(Compartment compartment)
    {
        return compartment.First.Intersect(compartment.Second).First();
    }

    private record PriorityItem(int Priority, char Item);
    
    private record Compartment(string First, string Second);
}