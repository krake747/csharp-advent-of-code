using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 9, "Rope Bridge")]
public class Day09Tests
{
    private readonly Day09 _sut;

    public Day09Tests()
    {
        // Arrange
        _sut = new Day09();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day09_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> TestData2 => FetchFile(@"..\..\..\Data\Day09_Test_2.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day09.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 13 },
        { RealData, 6030 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 1 },
        { TestData2, 36 },
        { RealData, 2545 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many positions does the tail of the rope visit at least once?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many positions does the tail of the rope visit at least once?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}