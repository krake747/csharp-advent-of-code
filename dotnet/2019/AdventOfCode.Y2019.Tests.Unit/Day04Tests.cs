using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2019.Tests.Unit;

[AocPuzzle(2019, 4, "Secure Container")]
public sealed class Day04Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day04);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day04 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(RealData), 481 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(RealData), 299 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many different passwords")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many different passwords")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}