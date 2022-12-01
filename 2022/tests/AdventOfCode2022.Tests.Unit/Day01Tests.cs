using AdventOfCodeLib;

namespace AdventOfCode2022.Tests.Unit;

public class Day01Tests
{
    private static IEnumerable<string> RealData => TextFileReaderService.Fetch(@"..\..\..\Inputs\", "Day01.txt"); 

    public static TheoryData<string[], int> Part1Data => new()
    {
        {
            new[] { "1000", "2000", "3000", "", "4000", "", "5000", "6000", "", "7000", "8000", "9000", "", "10000" },
            24000
        },
        {
            RealData.ToArray(),
            69795
        }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    public void Part1_ShouldReturnInteger_WhenTryingToFindTheElfCarryingTheMostCalories(string[] values, int expected)
    {
        // Act
        var result = new Day01().Part1(values);

        // Assert
        result.Should().Be(expected);
    }
    //
    // [Theory]
    // [MemberData(nameof(Part1Data))]
    // public void Part2_ShouldReturnInteger_WhenEnumerableIsInteger(string[] values, int expected)
    // {
    //     // Act
    //     var result = new Day01().Part2(values);
    //
    //     // Assert
    //     result.Should().Be(expected);
    // }
}