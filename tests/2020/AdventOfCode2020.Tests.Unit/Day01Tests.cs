using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 01 - Report Repair")]
public class Day01Tests
{
    private readonly Day01 _sut;

    public Day01Tests()
    {
        // Arrange
        _sut = new Day01();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day01_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day01.txt", ReadAsEnumerable);
    
    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 514579 },
        { RealData, 935419 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 241861950 },
        { RealData, 49880012 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Find the two entries that sum to 2020; what do you get if you multiply them together?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Find the two entries that sum to 2020; what do you get if you multiply them together?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}