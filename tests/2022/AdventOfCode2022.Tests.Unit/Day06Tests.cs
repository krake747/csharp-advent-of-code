using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

// ReSharper disable StringLiteralTypo

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 06 - Tuning Trouble")]
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
        { TestData, 7 },
        { RealData, 1766 }
    };

    public static TheoryData<string, int> Part2Data => new()
    {
        { TestData, 19 },
        { RealData, 2383 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many characters need to be processed before the first start-of-packet marker is detected?")]
    public void Part1_ShouldReturnInteger(string values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many characters need to be processed before the first start-of-message marker is detected?")]
    public void Part2_ShouldReturnInteger(string values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}