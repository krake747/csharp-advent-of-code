using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 03 - Toboggan Trajectory")]
public class Day03Tests
{
    private readonly Day03 _sut;

    public Day03Tests()
    {
        // Arrange
        _sut = new Day03();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day03_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day03.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, long> Part1Data => new()
    {
        { TestData, 7 },
        { RealData, 214 }
    };

    public static TheoryData<IEnumerable<string>, long> Part2Data => new()
    {
        { TestData, 336 },
        { RealData, 8336352024L }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Following a slope of right 3 and down 1, how many trees would you encounter?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, long expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What do you get if you multiply together the number of trees encountered on each of the slopes?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, long expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}