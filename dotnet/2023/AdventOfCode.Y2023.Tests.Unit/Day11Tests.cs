using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2023.Tests.Unit;

[AocPuzzle(2023, 11, "Cosmic Expansion")]
public sealed class Day11Tests : IAocDayTest<long>
{
    private const string Day = nameof(Day11);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day11 _sut = new();

    public static TheoryData<AocInput, long> Part1Data => new()
    {
        { ReadInput(TestData), 374 },
        { ReadInput(RealData), 9799681 }
    };

    public static TheoryData<AocInput, long> Part2Data => new()
    {
        { ReadInput(TestData), 82000210 },
        { ReadInput(RealData), 513171773355 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of these lengths?")]
    public void Part1(AocInput input, long expected)
    {
        // Act
        var result = Day11.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of these lengths?")]
    public void Part2(AocInput input, long expected)
    {
        // Act
        var result = Day11.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}