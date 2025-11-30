using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2023.Tests.Unit;

[AocPuzzle(2023, 9, "Mirage Maintenance")]
public sealed class Day09Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day09);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day09 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 114 },
        { ReadInput(RealData), 1798691765 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 1104 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of these extrapolated values?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of these extrapolated values?")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part2(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of these extrapolated values?")]
    public void Part1A(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part1A(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of these extrapolated values?")]
    public void Part2A(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part2A(input);

        // Assert
        result.Should().Be(expected);
    }
}