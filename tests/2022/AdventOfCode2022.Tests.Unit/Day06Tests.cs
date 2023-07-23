using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

// ReSharper disable StringLiteralTypo

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 06 - Tuning Trouble")]
public sealed class Day06Tests
{
    private const string Day = nameof(Day06);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day06 _sut;

    public Day06Tests()
    {
        _sut = new Day06();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 7 },
        { ReadInput(RealData), 1766 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 19 },
        { ReadInput(RealData), 2383 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many characters need to be processed before the first start-of-packet marker is detected?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many characters need to be processed before the first start-of-message marker is detected?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}