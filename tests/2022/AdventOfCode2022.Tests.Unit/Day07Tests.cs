using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 07 - No Space Left On Device")]
public class Day07Tests
{
    private readonly Day07 _sut;

    public Day07Tests()
    {
        // Arrange
        _sut = new Day07();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day07_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day07.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 95437 },
        { RealData, 1543140 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 24933642 },
        { RealData, 1117448 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Total size of at most 100000. What is the sum of the total sizes of those directories?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the total size of that directory?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}