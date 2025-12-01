using System.ComponentModel;
using AdventOfCode.Lib;
using AdventOfCode.Y2024.FSharp;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 1, "Historian Hysteria", "C#", "F#")]
public sealed class Day01Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 11 },
        { ReadInput(RealData), 1660292 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 31 },
        { ReadInput(RealData), 22776016 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the total distance between your lists?")]
    public void Part1(AocInput input, int expected)
    {
        var result = Day01.Part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is their similarity score?")]
    public void Part2(AocInput input, int expected)
    {
        var result = Day01.Part2(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the total distance between your lists?")]
    public void FSharp_Part1(AocInput input, int expected)
    {
        var result = Fay01.part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is their similarity score?")]
    public void FSharp_Part2(AocInput input, int expected)
    {
        var result = Fay01.part2(input);

        result.Should().Be(expected);
    }
}