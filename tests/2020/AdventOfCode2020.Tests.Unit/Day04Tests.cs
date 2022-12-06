using System.ComponentModel;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 04 - Toboggan Trajectory")]
public class Day04Tests
{
    private readonly Day04 _sut;

    public Day04Tests()
    {
        // Arrange
        _sut = new Day04();
    }

    private static string TestData => FetchFile(@"..\..\..\Data\Day04_Test.txt", ReadAsString);
    private static string RealData => FetchFile(@"..\..\..\Data\Day04.txt", ReadAsString);
    private static string TestInvalidData => FetchFile(@"..\..\..\Data\Day04_Test_Invalid.txt", ReadAsString);
    private static string TestValidData => FetchFile(@"..\..\..\Data\Day04_Test_Valid.txt", ReadAsString);

    public static TheoryData<string, int> Part1Data => new()
    {
        { TestData, 2 },
        { RealData, 170 }
    };

    public static TheoryData<string, int> Part2Data => new()
    {
        { TestInvalidData, 0 },
        { TestValidData, 4 },
        { RealData, 103 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Count the number of valid passports. In your batch file, how many passports are valid?")]
    public void Part1_ShouldReturnInteger(string values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Count the number of valid passports. In your batch file, how many passports are valid?")]
    public void Part2_ShouldReturnInteger(string values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}