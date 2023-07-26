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

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
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
        var result = Day07.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day07.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}