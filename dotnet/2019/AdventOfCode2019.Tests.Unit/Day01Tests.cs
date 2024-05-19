using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode2019.Tests.Unit;

[AocPuzzle(2022, 1, "The Tyranny of the Rocket Equation")]
public sealed class Day01Tests
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day01 _sut;

    public Day01Tests()
    {
        // Arrange
        _sut = new Day01();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 34241 },
        { ReadInput(RealData), 3296269 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 51316 },
        { ReadInput(RealData), 4941547 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of the fuel requirements for all of the modules on your spacecraft?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of the fuel requirements for all of the modules on your spacecraft?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}