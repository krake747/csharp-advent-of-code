using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 13, "Distress Signal")]
public class Day13Tests
{
    private readonly Day13 _sut;

    public Day13Tests()
    {
        // Arrange
        _sut = new Day13();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day13_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day13.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 13 },
        { RealData, 5503 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 2 },
        { RealData, 2 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Determine pairs in the right order. What is the sum of the indices of those pairs?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Determine pairs in the right order. What is the sum of the indices of those pairs?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}