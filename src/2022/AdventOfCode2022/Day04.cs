using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

public class Day04 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(CreateAssignedSections)
            .Select(sections => sections.Chunk(2))
            .Count(sectionsRanges => SectionsRanges(sectionsRanges, AreBoundsWithin));
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.Select(CreateAssignedSections)
            .Select(sections => sections.Chunk(2))
            .Count(sectionsRanges => SectionsRanges(sectionsRanges, AreBoundsOverlapping));
    }

    private static IEnumerable<int> CreateAssignedSections(string pairOfElves)
    {
        return pairOfElves.Split(',', '-').Select(int.Parse);
    }

    private static bool SectionsRanges(IEnumerable<IEnumerable<int>> ranges, Func<Bounds, Bounds, bool> predicate)
    {
        var sectionRanges = ranges.ToArray();
        var firstSections = Bounds.Create(sectionRanges.First());
        var secondSections = Bounds.Create(sectionRanges.Last());

        return predicate(firstSections, secondSections) || predicate(secondSections, firstSections);
    }

    private static bool AreBoundsWithin(Bounds leftSection, Bounds rightSection)
    {
        return leftSection.IsWithin(rightSection);
    }

    private static bool AreBoundsOverlapping(Bounds leftSection, Bounds rightSection)
    {
        return leftSection.IsOverlapping(rightSection);
    }
}

internal readonly record struct Bounds(int Lower, int Upper)
{
    internal static Bounds Create(IEnumerable<int> stream)
    {
        var array = stream.Order().ToArray();
        return new Bounds(array.First(), array.Last());
    }
}

internal static class Day04Extensions
{
    internal static bool IsWithin(this Bounds leftSection, Bounds rightSection)
    {
        return leftSection.Lower.IsNumberWithin(rightSection) && leftSection.Upper.IsNumberWithin(rightSection);
    }

    internal static bool IsOverlapping(this Bounds leftSection, Bounds rightSection)
    {
        return leftSection.Lower <= rightSection.Upper && rightSection.Lower <= leftSection.Upper;
    }

    private static bool IsNumberWithin(this int number, Bounds bounds)
    {
        return bounds.Lower <= number && number <= bounds.Upper;
    }
}