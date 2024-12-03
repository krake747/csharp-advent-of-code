using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 3, "Mull It Over", "C#")]
public sealed class Day03Tests : IAocDayTest<long>
{
    private const string Day = nameof(Day03);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestData2 = @$"..\..\..\Data\{Day}_Test_2.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, long> Part1Data => new()
    {
        { ReadInput(TestData), 161 },
        { ReadInput(RealData), 166357705 }
    };

    public static TheoryData<AocInput, long> Part2Data => new()
    {
        { ReadInput(TestData2), 48 },
        { ReadInput(RealData), 88811886 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What do you get if you add up all of the results of the multiplications?")]
    public void Part1(AocInput input, long expected)
    {
        var result = Day03.Part1(input);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What do you get if you add up all of the results of just the enabled multiplications?")]
    public void Part2(AocInput input, long expected)
    {
        var result = Day03.Part2(input);
    
        result.Should().Be(expected);
    }
}