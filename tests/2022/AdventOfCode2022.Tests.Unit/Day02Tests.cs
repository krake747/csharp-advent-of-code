using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 02 - Rock Paper Scissors")]
public sealed class Day02Tests
{
    private readonly Day02 _sut;
    private const string Day = nameof(Day02);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 15 },
        { ReadInput(RealData), 9241 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 12 },
        { ReadInput(RealData), 14610 }
    };
    
    public Day02Tests()
    {
        _sut = new Day02();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What would your total score be if everything goes exactly according to your strategy guide?")]
    public void Part1_ShouldReturnInteger_WhenFollowingTheShapeStrategyGuide(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What would your total score be if everything goes exactly according to your strategy guide?")]
    public void Part2_ShouldReturnInteger_WhenFollowingTheOutcomeStrategyGuide(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}