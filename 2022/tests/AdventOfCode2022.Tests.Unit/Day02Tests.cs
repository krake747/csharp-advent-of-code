using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 02 - Rock Paper Scissors")]
public class Day02Tests
{
    private readonly Day02 _sut;

    public Day02Tests()
    {
        // Arrange
        _sut = new Day02();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\TestInput\Day02.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Input\Day02.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 15 },
        { RealData, 9241 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 12 },
        { RealData, 14610 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What would your total score be if everything goes exactly according to your strategy guide?")]
    public void Part1_ShouldReturnInteger_WhenFollowingTheShapeStrategyGuide(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What would your total score be if everything goes exactly according to your strategy guide?")]
    public void Part2_ShouldReturnInteger_WhenFollowingTheOutcomeStrategyGuide(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}