using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("day 01 - Calorie Counting")]
public class Day01Tests
{
    private readonly Day01 _sut;

    public Day01Tests()
    {
        // Arrange
        _sut = new Day01();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day01_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day01.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 24000 },
        { RealData, 69795 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 45000 },
        { RealData, 208437 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many total Calories is that Elf carrying?")]
    public void Part1_ShouldReturnInteger_WhenSearchingTheElfCarryingTheMostCalories(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many Calories are those Elves carrying in total?")]
    public void Part2_ShouldReturnInteger_WhenSearchingTheTopThreeElvesCarryingTheMostCalories(IEnumerable<string> values,
        int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}