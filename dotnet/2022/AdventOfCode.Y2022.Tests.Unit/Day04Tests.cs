﻿using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2022.Tests.Unit;

[Description("Day 04 - Camp Cleanup")]
public sealed class Day04Tests
{
    private const string Day = nameof(Day04);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day04 _sut;

    public Day04Tests()
    {
        _sut = new Day04();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 605 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 4 },
        { ReadInput(RealData), 914 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("In how many assignment pairs does one range fully contain the other?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("In how many assignment pairs do the ranges overlap?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}