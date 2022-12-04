using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 04 - Camp Cleanup")]
public class Day04Tests
{
    private readonly Day04 _sut;

    public Day04Tests()
    {
        // Arrange
        _sut = new Day04();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day04_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day04.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 2 },
        { RealData, 605 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 4 },
        { RealData, 914 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("In how many assignment pairs does one range fully contain the other?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("In how many assignment pairs do the ranges overlap?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}