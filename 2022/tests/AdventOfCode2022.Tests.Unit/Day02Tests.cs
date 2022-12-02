using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

public class Day02Tests
{
    private readonly Day02 _sut;

    public Day02Tests()
    {
        // Arrange
        _sut = new Day02();
    }
    
    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\TestInput\Day02.txt", ReadAsEnumerable); 
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Input\Day02.txt", ReadAsEnumerable); 

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 15 },
        { RealData, 9241 }
    };
    
    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 12 },
        { RealData, 14610 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    public void Part1_ShouldReturnInteger_(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    public void Part2_ShouldReturnInteger_(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}