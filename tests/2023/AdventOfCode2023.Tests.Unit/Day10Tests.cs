using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2023.Tests.Unit;

[AocPuzzle(2023, 10, "Pipe Maze")]
public sealed class Day10Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day10);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestData2 = @$"..\..\..\Data\{Day}_Test_2.txt";
    private const string TestData3 = @$"..\..\..\Data\{Day}_Test_3.txt";
    private const string TestData4 = @$"..\..\..\Data\{Day}_Test_4.txt";
    private const string TestData5 = @$"..\..\..\Data\{Day}_Test_5.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day10 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 4 },
        { ReadInput(TestData2), 8 },
        { ReadInput(RealData), 6931 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        // { ReadInput(TestData), 1 },
        // { ReadInput(TestData3), 4 },
        // { ReadInput(TestData4), 8 },
        // { ReadInput(TestData5), 10 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many steps along the loop does it take to get from the starting position to the point farthest from the starting position?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day10.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many tiles are enclosed by the loop?")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day10.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}