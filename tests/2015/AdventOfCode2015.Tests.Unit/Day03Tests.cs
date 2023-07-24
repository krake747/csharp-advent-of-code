using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 3, "Perfectly Spherical Houses in a Vacuum")]
public sealed class Day03Tests
{
    private const string Day = nameof(Day03);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day03 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 4 },
        { ReadInput(RealData), 2592 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 4 },
        { ReadInput(RealData), 1 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many houses receive at least one present?")]
    public void Part1_ShouldReturnInteger_WhenSantaDeliversPresents(AocInput input, int expected)
    {
        // Act
        var result = Day03.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many total feet of ribbon should they order?")]
    public void Part2_ShouldReturnInteger_WhenElvesOrderWrappingPaper2(AocInput input,
        int expected)
    {
        // Act
        var result = Day03.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}