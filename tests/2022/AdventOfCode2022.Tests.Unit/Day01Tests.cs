using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 01 - Calorie Counting")]
public sealed class Day01Tests
{
    private readonly Day01 _sut;
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 24000 },
        { ReadInput(RealData), 69795 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 45000 },
        { ReadInput(RealData), 208437 }
    };
    
    public Day01Tests()
    {
        _sut = new Day01();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many total Calories is that Elf carrying?")]
    public void Part1_ShouldReturnInteger_WhenSearchingTheElfCarryingTheMostCalories(AocInput input, int expected)
    {
        // Arrange
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
        // Arrange
        // Act
        var result = Day01.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}