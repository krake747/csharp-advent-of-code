using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 2, "Not Quite Lisp")]
public sealed class Day02Tests
{
    private const string Day = nameof(Day02);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day02 _sut;

    public Day02Tests()
    {
        _sut = new Day02();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 58 },
        { ReadInput(RealData), 1598415 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 34 },
        { ReadInput(RealData), 3812909 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many total square feet of wrapping paper should they order?")]
    public void Part1_ShouldReturnInteger_WhenElvesOrderWrappingPaper(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("")]
    public void Part2_ShouldReturnInteger_WhenElvesOrderWrappingPaper2(AocInput input,
        int expected)
    {
        // Act
        var result = Day02.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}