using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 05 - Binary Boarding")]
public class Day05Tests
{
    private readonly Day05 _sut;

    public Day05Tests()
    {
        // Arrange
        _sut = new Day05();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day05_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day05.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 820 },
        { RealData, 930 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { RealData, 515 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the highest seat ID on a boarding pass?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the ID of your seat?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}