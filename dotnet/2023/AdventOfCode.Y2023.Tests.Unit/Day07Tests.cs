using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2023.Tests.Unit;

[AocPuzzle(2023, 7, "Camel Cards")]
public sealed class Day07Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day07);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day07 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 6440 },
        { ReadInput(RealData), 248559379 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 5905 },
        { ReadInput(RealData), 249631254 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What are the total winnings?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day07.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What are the new total winnings?")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day07.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}