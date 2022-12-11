using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2019.Tests.Unit;

[AocPuzzle(2022, 1, "The Tyranny of the Rocket Equation")]
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
        { TestData, 34241 },
        { RealData, 3296269 }
    };

    public static TheoryData<IEnumerable<string>, int> Part2Data => new()
    {
        { TestData, 51316 },
        { RealData, 4941547 }
    };


    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of the fuel requirements for all of the modules on your spacecraft?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of the fuel requirements for all of the modules on your spacecraft?")]
    public void Part2_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}