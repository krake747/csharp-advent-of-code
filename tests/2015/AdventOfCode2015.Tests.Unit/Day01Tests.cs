using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[Description("Day 01 - Not Quite Lisp")]
public sealed class Day01Tests
{
    private readonly Day01 _sut;
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 2 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 2 }
    };
    
    public Day01Tests()
    {
        _sut = new Day01();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many total Calories is that Elf carrying?")]
    public void Part1_ShouldReturnInteger_WhenSantaDeliversPresents(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many Calories are those Elves carrying in total?")]
    public void Part2_ShouldReturnInteger_WhenSearchingTheTopThreeElvesCarryingTheMostCalories(AocInput input,
        int expected)
    {
        // Act
        var result = Day01.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}