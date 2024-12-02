using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 2, "Red-Nosed Reports", "C#")]
public sealed class Day02Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day02);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 369 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 4 },
        { ReadInput(RealData), 428 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many reports are safe?")]
    public void Part1(AocInput input, int expected)
    {
        var result = Day02.Part1(input);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many reports are now safe?")]
    public void Part2(AocInput input, int expected)
    {
        var result = Day02.Part2(input);
    
        result.Should().Be(expected);
    }
}