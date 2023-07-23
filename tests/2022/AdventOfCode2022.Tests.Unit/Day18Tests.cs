using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 18, "Boiling Boulders")]
public sealed class Day18Tests
{
    private const string Day = nameof(Day18);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day18 _sut;

    public Day18Tests()
    {
        // Arrange
        _sut = new Day18();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 64 },
        { ReadInput(RealData), 3564 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 64 },
        { ReadInput(RealData), 64 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the surface area of your scanned lava droplet?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day18.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    // [Theory]
    // [MemberData(nameof(Part2Data))]
    // [Description("What is the surface area of your scanned lava droplet?")]
    // public void Part2_ShouldReturnInteger(AocInput input, int expected)
    // {
    //     // Act
    //     var result = Day18.Part2(input);
    //
    //     // Assert
    //     result.Should().Be(expected);
    // }
}