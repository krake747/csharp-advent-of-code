using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2022.Tests.Unit;

[Description("Day 08 - Treetop Tree House")]
public sealed class Day08Tests
{
    private const string Day = nameof(Day08);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day08 _sut;

    public Day08Tests()
    {
        _sut = new Day08();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 21 },
        { ReadInput(RealData), 1816 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 8 },
        { ReadInput(RealData), 383520 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Consider your map. How many trees are visible from outside the grid?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day08.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Consider your map. What is the highest scenic score possible for any tree?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day08.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}