using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2019.Tests.Unit;

[AocPuzzle(2019, 2, "1202 Program Alarm")]
public sealed class Day02Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day02);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day02 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(RealData), 3790645 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(RealData), 6577 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What value is left at position 0 after the program halts?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is 100 * noun + verb?")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}