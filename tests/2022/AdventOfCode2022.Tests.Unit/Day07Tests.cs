﻿using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 07 - No Space Left On Device")]
public sealed class Day07Tests
{
    private readonly Day07 _sut;
    private const string Day = nameof(Day07);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 95437 },
        { ReadInput(RealData), 1543140 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 24933642 },
        { ReadInput(RealData), 1117448 }
    };
    
    public Day07Tests()
    {
        // Arrange
        _sut = new Day07();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Total size of at most 100000. What is the sum of the total sizes of those directories?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day07.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the total size of that directory?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day07.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}