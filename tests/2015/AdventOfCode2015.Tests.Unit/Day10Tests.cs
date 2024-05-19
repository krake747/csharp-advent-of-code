using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 10, "Elves Look, Elves Say")]
public sealed class Day10Tests
{
    private const string Day = nameof(Day10);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day10 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        //{ ReadInput(TestData), 0 },
        { ReadInput(RealData), 252594 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        //{ ReadInput(TestData), 0 },
        { ReadInput(RealData), 3579328 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the length of the result? Repeating 40 times")]
    public void Part1_ShouldReturnInteger_WhenElvesPlayLookAndSay(AocInput input, int expected)
    {
        // Act
        var result = Day10.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the length of the result? Repeating 50 times")]
    public void Part2_ShouldReturnInteger_WhenElvesPlayLookAndSay(AocInput input, int expected)
    {
        // Act
        var result = Day10.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}