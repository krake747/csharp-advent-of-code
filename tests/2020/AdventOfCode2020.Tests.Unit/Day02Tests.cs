using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 02 - Password Philosophy")]
public class Day02Tests
{
    private readonly Day02 _sut;

    public Day02Tests()
    {
        // Arrange
        _sut = new Day02();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day02_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day02.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 2 },
        { RealData, 572 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 1 },
        { RealData, 306 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many passwords are valid according to their policies?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many passwords are valid according to the new interpretation of the policies?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}