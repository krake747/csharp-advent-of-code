using System.ComponentModel;
using AdventOfCode.Lib;
using AdventOfCode.Y2024.FSharp;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 4, "Ceres Search", "C#")]
public sealed class Day04Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day04);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 18 },
        { ReadInput(RealData), 2358 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 9 },
        { ReadInput(RealData), 1737 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many times does XMAS appear?")]
    public void Part1(AocInput input, int expected)
    {
        var result = Day04.Part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many times does an X-MAS appear?")]
    public void Part2(AocInput input, int expected)
    {
        var result = Day04.Part2(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many times does XMAS appear?")]
    public void FSharp_Part1(AocInput input, int expected)
    {
        var result = Fay04.part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many times does an X-MAS appear?")]
    public void FSharp_Part2(AocInput input, int expected)
    {
        var result = Fay04.part2(input);

        result.Should().Be(expected);
    }
}