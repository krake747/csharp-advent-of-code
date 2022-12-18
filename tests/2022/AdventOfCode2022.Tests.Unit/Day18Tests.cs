using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 18, "Boiling Boulders")]
public class Day18Tests
{
    private readonly Day18 _sut;

    public Day18Tests()
    {
        // Arrange
        _sut = new Day18();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day18_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day18.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 64 },
        { RealData, 3564 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 64 },
        { RealData, 64 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the surface area of your scanned lava droplet?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the surface area of your scanned lava droplet?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}