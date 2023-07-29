using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 7, "Some Assembly Required")]
public sealed class Day07Tests
{
    private const string Day = nameof(Day07);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day07 _sut = new();

    public static TheoryData<AocInput, ushort> Part1Data => new()
    {
        // { ReadInput(TestData), 0 },
        { ReadInput(RealData), 46065 }
    };

    public static TheoryData<AocInput, ushort> Part2Data => new()
    {
        // { ReadInput(TestData), 0 },
        { ReadInput(RealData), 14134 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What signal is ultimately provided to wire a?")]
    public void Part1_ShouldReturnInteger_WhenSantaUsesWires(AocInput input, ushort expected)
    {
        // Act
        var result = Day07.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What signal is ultimately provided to wire b?")]
    public void Part2_ShouldReturnIntegerWhenSantaUsesWires(AocInput input, ushort expected)
    {
        // Act
        var result = Day07.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}