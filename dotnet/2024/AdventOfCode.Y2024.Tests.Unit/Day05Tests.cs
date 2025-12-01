using System.ComponentModel;
using AdventOfCode.Lib;
using AdventOfCode.Y2024.FSharp;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 5, "Print Queue", "C#")]
public sealed class Day05Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day05);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 143 },
        { ReadInput(RealData), 7307 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 123 },
        { ReadInput(RealData), 4713 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What do you get if you add up the middle page number from those correctly-ordered updates?")]
    public void Part1(AocInput input, int expected)
    {
        var result = Day05.Part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What do you get if you add up the middle page numbers after correctly ordering just those updates?")]
    public void Part2(AocInput input, int expected)
    {
        var result = Day05.Part2(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What do you get if you add up the middle page number from those correctly-ordered updates?")]
    public void FSharp_Part1(AocInput input, int expected)
    {
        var result = Fay05.part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What do you get if you add up the middle page numbers after correctly ordering just those updates?")]
    public void FSharp_Part2(AocInput input, int expected)
    {
        var result = Fay05.part2(input);

        result.Should().Be(expected);
    }
}