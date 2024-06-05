using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2019.Tests.Unit;

[AocPuzzle(2019, 3, "Crossed Wires")]
public sealed class Day03Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day03);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day03 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 159 },
        { ReadInput(RealData), 403 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 610 },
        { ReadInput(RealData), 4158 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the Manhattan distance from the central port to the closest intersection?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day03.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the fewest combined steps the wires must take to reach an intersection?")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day03.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}