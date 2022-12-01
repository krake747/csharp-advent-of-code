using AdventOfCodeLib;

namespace AdventOfCode2022.Tests.Unit;

public class Day01Tests
{
    private static IEnumerable<string> TestData => TextFileReaderService.Fetch(@"..\..\..\TestInput\", "Day01.txt"); 
    private static IEnumerable<string> RealData => TextFileReaderService.Fetch(@"..\..\..\Input\", "Day01.txt"); 

    public static TheoryData<string[], int> Part1Data => new()
    {
        {
            TestData.ToArray(),
            24000
        },
        {
            RealData.ToArray(),
            69795
        }
    };
    
    public static TheoryData<string[], int> Part2Data => new()
    {
        {
            TestData.ToArray(),
            45000
        },
        {
            RealData.ToArray(),
            208437
        }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    public void Part1_ShouldReturnInteger_WhenSearchingTheElfCarryingTheMostCalories(string[] values, int expected)
    {
        // Arrange
        var sut = new Day01();
        
        // Act
        var result = sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    public void Part2_ShouldReturnInteger_WhenSearchingTheTopThreeElvesCarryingTheMostCalories(string[] values, 
        int expected)
    {
        // Arrange
        var sut = new Day01();
        
        // Act
        var result = sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}