using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 1, "Not Quite Lisp")]
public sealed class Day01Tests
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day01 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), -1 },
        { ReadInput(RealData), 74 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 5 },
        { ReadInput(RealData), 1795 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("To what floor do the instructions take Santa?")]
    public void Part1_ShouldReturnInteger_WhenSantaDeliversPresents(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the position of the character that causes Santa to first enter the basement?")]
    public void Part1_ShouldReturnInteger_WhenSantaDeliversPresentsToBasement(AocInput input,
        int expected)
    {
        // Act
        var result = Day01.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}