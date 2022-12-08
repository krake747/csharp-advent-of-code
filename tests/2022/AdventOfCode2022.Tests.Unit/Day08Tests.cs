using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 08 - Treetop Tree House")]
public class Day08Tests
{
    private readonly Day08 _sut;

    public Day08Tests()
    {
        // Arrange
        _sut = new Day08();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day08_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day08.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 21 },
        { RealData, 1816 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 8 },
        { RealData, 383520 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Consider your map. How many trees are visible from outside the grid?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Consider your map. What is the highest scenic score possible for any tree?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}