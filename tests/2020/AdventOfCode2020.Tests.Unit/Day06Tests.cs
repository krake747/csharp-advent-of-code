using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 06 - Custom Customs")]
public class Day06Tests
{
    private readonly Day06 _sut;

    public Day06Tests()
    {
        // Arrange
        _sut = new Day06();
    }

    private static string TestData => FetchFile(@"..\..\..\Data\Day06_Test.txt", ReadAsString);
    private static string RealData => FetchFile(@"..\..\..\Data\Day06.txt", ReadAsString);

    public static TheoryData<string, int> Part1Data => new()
    {
        { TestData, 11 },
        { RealData, 7027 }
    };

    public static TheoryData<string, int> Part2Data => new()
    {
        { TestData, 6 },
        { RealData, 3579 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Count the number of questions to which anyone answered yes. What is the sum of those counts?")]
    public void Part1_ShouldReturnInteger(string values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Count the number of questions to which everyone answered yes. What is the sum of those counts?")]
    public void Part2_ShouldReturnInteger(string values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}