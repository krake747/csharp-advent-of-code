using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2019.Tests.Unit;

[AocPuzzle(2019, 5, "Sunny with a Chance of Asteroids")]
public sealed class Day05Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day05);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day05 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(RealData), 9961446 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(RealData), 742621 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("what diagnostic code does the program produce?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the diagnostic code for system ID 5?")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}