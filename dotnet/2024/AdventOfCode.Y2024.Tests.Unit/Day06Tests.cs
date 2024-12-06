using System.ComponentModel;
using AdventOfCode.Lib;
using AdventOfCode.Y2024.FSharp;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 6, "Guard Gallivant", "C#")]
public sealed class Day06Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day06);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 41 },
        { ReadInput(RealData), 5305 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 6 },
        { ReadInput(RealData), 2143 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many distinct positions will the guard visit before leaving the mapped area?")]
    public void Part1(AocInput input, int expected)
    {
        var result = Day06.Part1(input);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void Part2(AocInput input, int expected)
    {
        var result = Day06.Part2(input);
    
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many distinct positions will the guard visit before leaving the mapped area?")]
    public void FSharp_Part1(AocInput input, int expected)
    {
        var result = Fay06.part1(input);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void FSharp_Part2(AocInput input, int expected)
    {
        var result = Fay06.part2(input);
    
        result.Should().Be(expected);
    }
}