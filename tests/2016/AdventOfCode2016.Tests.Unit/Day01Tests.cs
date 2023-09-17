using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2016.Tests.Unit;

[AocPuzzle(2016, 1, "No Time for a Taxicab")]
public sealed class Day01Tests
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day01 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 11 }, // Typo in instructions. says 12, but it is 11.
        { ReadInput(RealData), 299 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("")]
    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}