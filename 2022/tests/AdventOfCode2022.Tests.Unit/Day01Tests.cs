using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

public class Day01Tests
{
    private readonly Day01 _sut;

    public Day01Tests()
    {
        // Arrange
        _sut = new Day01();
    }
    
    private static string TestData => FetchFile(@"..\..\..\TestInput\Day01.txt", ReadAsString); 
    private static string RealData => FetchFile(@"..\..\..\Input\Day01.txt", ReadAsString); 

    public static TheoryData<string, int> Part1Data => new()
    {
        { TestData, 24000 },
        { RealData, 69795 }
    };
    
    public static TheoryData<string, int> Part2Data => new()
    {
        { TestData, 45000 },
        { RealData, 208437 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    public void Part1_ShouldReturnInteger_WhenSearchingTheElfCarryingTheMostCalories(string values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    public void Part2_ShouldReturnInteger_WhenSearchingTheTopThreeElvesCarryingTheMostCalories(string values, 
        int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}