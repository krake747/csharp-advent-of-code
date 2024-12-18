using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2019.Tests.Unit;

[AocPuzzle(2019, 6, "Universal Orbit Map")]
public sealed class Day06Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day06);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day06 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}