using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 11, "Monkey in the Middle")]
public class Day11Tests
{
    private readonly Day11 _sut;

    public Day11Tests()
    {
        // Arrange
        _sut = new Day11();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day11_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day11.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, long> Part1Data => new()
    {
        { TestData, 10605L },
        { RealData, 56120L }
    };

    public static TheoryData<IEnumerable<string>, long> Part2Data => new()
    { 
        { TestData, 2713310158L },
        //{ RealData, 2713310158L }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, long expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, long expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}