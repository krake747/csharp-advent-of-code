using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2020.Tests.Unit;

[Description("Day 01 - Report Repair")]
public sealed class Day01Tests
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day01 _sut;

    public Day01Tests()
    {
        // Arrange
        _sut = new Day01();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 514579 },
        { ReadInput(RealData), 935419 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 241861950 },
        { ReadInput(RealData), 49880012 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Find the two entries that sum to 2020; what do you get if you multiply them together?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("In your expense report, what is the product of the three entries that sum to 2020?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}