using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 03 - Rucksack Reorganization")]
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

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 157 },
        { RealData, 8202 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 70 },
        { RealData, 2864 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of the priorities of those item types?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of the priorities of those item types?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}