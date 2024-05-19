using System.ComponentModel;
using AdventOfCode.Lib;
using AdventOfCode2023.FSharp;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2023.Tests.Unit;

[AocPuzzle(2023, 8, "Haunted Wasteland", "F#")]
public sealed class Fay08Tests : IAocDayTest<long>
{
    private const string Day = nameof(Day08);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestData2 = @$"..\..\..\Data\{Day}_Test_2.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day08 _sut = new();

    public static TheoryData<AocInput, long> Part1Data => new()
    {
        { ReadInput(TestData), 6 },
        { ReadInput(RealData), 21251 }
    };

    public static TheoryData<AocInput, long> Part2Data => new()
    {
        { ReadInput(TestData2), 6 },
        { ReadInput(RealData), 11678319315857 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many steps are required to reach ZZZ?")]
    public void Part1(AocInput input, long expected)
    {
        // Act
        var result = Fay08.part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many steps does it take before you're only on nodes that end with Z?")]
    public void Part2(AocInput input, long expected)
    {
        // Act
        var result = Fay08.part2(input);

        // Assert
        result.Should().Be(expected);
    }
}