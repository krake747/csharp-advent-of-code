using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 12, "Hill Climbing Algorithm")]
public class Day12Tests
{
    private readonly Day12 _sut;

    public Day12Tests()
    {
        // Arrange
        _sut = new Day12();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day12_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day12.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 1 },
        { RealData, 1 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 1 },
        { RealData, 1 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the fewest steps required to move from your current position to the location that should " +
                 "get the best signal?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the fewest steps required to move from your current position to the location that should " +
                 "get the best signal?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}