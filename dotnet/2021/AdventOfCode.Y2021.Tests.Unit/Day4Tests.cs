﻿using System.Collections;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2021.Tests.Unit;

public class Day4Tests
{
    [Theory]
    [ClassData(typeof(Day4Part1TestData))]
    public void Part1_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day4.Part1(values);

        // Assert 
        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(Day4Part2TestData))]
    public void Part2_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day4.Part2(values);

        // Assert 
        result.Should().Be(expected);
    }
}

public class Day4Part1TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new[]
            {
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                "22 13 17 11  0",
                " 8  2 23  4 24",
                "21  9 14 16  7",
                " 6 10  3 18  5",
                " 1 12 20 15 19",
                "",
                " 3 15  0  2 22",
                " 9 18 13 17  5",
                "19  8  7 25 23",
                "20 11 10 24  4",
                "14 21 16 12  6",
                "",
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7"
            },
            4512
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Day4Part2TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new[]
            {
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                "22 13 17 11  0",
                " 8  2 23  4 24",
                "21  9 14 16  7",
                " 6 10  3 18  5",
                " 1 12 20 15 19",
                "",
                " 3 15  0  2 22",
                " 9 18 13 17  5",
                "19  8  7 25 23",
                "20 11 10 24  4",
                "14 21 16 12  6",
                "",
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7"
            },
            1924
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}