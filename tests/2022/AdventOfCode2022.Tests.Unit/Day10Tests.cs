using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 10, "Cathode-Ray Tube")]
public class Day10Tests
{
    private readonly Day10 _sut;

    public Day10Tests()
    {
        // Arrange
        _sut = new Day10();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day10_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day10.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 13140 },
        { RealData, 13740 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    { 
        { TestData, 13140 },
        { RealData, 13140 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of these six signal strengths?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of these six signal strengths?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}