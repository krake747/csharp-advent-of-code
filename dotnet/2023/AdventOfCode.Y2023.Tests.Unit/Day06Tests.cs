using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2023.Tests.Unit;

[AocPuzzle(2023, 6, "Wait For It")]
public sealed class Day06Tests : IAocDayTest<long>
{
    private const string Day = nameof(Day06);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day06 _sut = new();

    public static TheoryData<AocInput, long> Part1Data => new()
    {
        { ReadInput(TestData), 288 },
        { ReadInput(RealData), 281600 }
    };

    public static TheoryData<AocInput, long> Part2Data => new()
    {
        { ReadInput(TestData), 71503 },
        { ReadInput(RealData), 33875953 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What do you get if you multiply these numbers together?")]
    public void Part1(AocInput input, long expected)
    {
        // Act
        var result = Day06.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many ways can you beat the record in this one much longer race?")]
    public void Part2(AocInput input, long expected)
    {
        // Act
        var result = Day06.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}