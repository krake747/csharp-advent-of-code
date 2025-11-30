using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2015.Tests.Unit;

[AocPuzzle(2015, 6, "Probably a Fire Hazard")]
public sealed class Day06Tests
{
    private const string Day = nameof(Day06);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestData2 = @$"..\..\..\Data\{Day}_Test_2.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day06 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 998996 },
        { ReadInput(RealData), 400410 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData2), 2000001 },
        { ReadInput(RealData), 15343601 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many lights are lit?")]
    public void Part1_ShouldReturnInteger_WhenSantaIsConfiguringLights(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the total brightness of all lights?")]
    public void Part2_ShouldReturnInteger_WhenSantaIsConfiguringLightBrightness(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}