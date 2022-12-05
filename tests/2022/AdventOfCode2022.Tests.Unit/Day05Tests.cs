using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

// ReSharper disable StringLiteralTypo

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 05 - ")]
public class Day05Tests
{
    private readonly Day05 _sut;

    public Day05Tests()
    {
        // Arrange
        _sut = new Day05();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day05_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day05.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, string> Part1Data => new()
    {
        { TestData, "CMZ" },
        { RealData, "ZRLJGSCTR" }
    };

    public static TheoryData<IEnumerable<string>, string> Part2Data => new()
    {
        { TestData, "MCD" },
        { RealData, "PRTTGRFPB" }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("After the rearrangement procedure completes, what crate ends up on top of each stack?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, string expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("After the rearrangement procedure completes, what crate ends up on top of each stack?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, string expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}