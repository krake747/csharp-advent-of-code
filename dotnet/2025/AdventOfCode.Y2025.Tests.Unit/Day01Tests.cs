using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2025.Tests.Unit;

[AocPuzzle(2025, 1, "Secret Entrance", "C#")]
public sealed class Day01Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 3 },
        { ReadInput(RealData), 0 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What's the actual password to open the door?")]
    public void Part1(AocInput input, int expected)
    {
        var result = Day01.Part1(input);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void Part2(AocInput input, int expected)
    {
        var result = Day01.Part2(input);

        result.Should().Be(expected);
    }
}