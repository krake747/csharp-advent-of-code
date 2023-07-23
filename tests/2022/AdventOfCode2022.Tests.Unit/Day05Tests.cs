using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

// ReSharper disable StringLiteralTypo

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 05 - Supply Stacks")]
public sealed class Day05Tests
{
    private readonly Day05 _sut;
    private const string Day = nameof(Day05);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, string> Part1Data => new()
    {
        { ReadInput(TestData), "CMZ" },
        { ReadInput(RealData), "ZRLJGSCTR" }
    };

    public static TheoryData<AocInput, string> Part2Data => new()
    {
        { ReadInput(TestData), "MCD" },
        { ReadInput(RealData), "PRTTGRFPB" }
    };
    
    public Day05Tests()
    {
        // Arrange
        _sut = new Day05();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("After the rearrangement procedure completes, what crate ends up on top of each stack?")]
    public void Part1_ShouldReturnInteger(AocInput input, string expected)
    {
        // Act
        var result = Day05.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("After the rearrangement procedure completes, what crate ends up on top of each stack?")]
    public void Part2_ShouldReturnInteger(AocInput input, string expected)
    {
        // Act
        var result = Day05.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}