//using System.Collections;
//using FluentAssertions;
//using Xunit;

//namespace AdventOfCode2021.Tests.Unit;

//public class DayXTests
//{
//    [Theory]
//    [ClassData(typeof(DayXPart1TestData))]
//    public void Part1_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
//    {
//        // Act
//        var result = DayX.Part1(values);

//        // Assert 
//        result.Should().Be(expected);
//    }
//}


//public class DayXPart1TestData : IEnumerable<object[]>
//{
//    public IEnumerator<object[]> GetEnumerator()
//    {
//        yield return new object[]
//        {
//            new string[]
//            {
//                "0,9 -> 5,9",
//            },
//            5
//        };
//    }

//    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//}

