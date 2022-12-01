using AdventOfCode2021;
using AdventOfCodeLib;

var parser = new TextFileParserService();

var inputDay1 = parser.Fetch("day01.txt")
    .Select(int.Parse)
    .ToList();

var result1 = Day1.Part1(inputDay1);
var result2 = Day1.Part2(inputDay1);

Console.WriteLine(result1);
Console.WriteLine(result2);

//var inputDay2 = parser.Fetch("day02.txt")
//                      .ToList();


//var result21 = Day2.Part1(inputDay2);
//var result22 = Day2.Part2(inputDay2);

//Console.WriteLine(result21);
//Console.WriteLine(result22);


//var inputDay3 = parser.Fetch("day03.txt")
//                      .ToList();


//var result31 = Day3.Part1(inputDay3);
//var result32 = Day3.Part2(inputDay3);

//Console.WriteLine(result31);
//Console.WriteLine(result32);

//var inputDay4 = parser.Fetch("day04.txt")
//                      .ToList();


//var result41 = Day4.Part1(inputDay4);
//var result42 = Day4.Part2(inputDay4);

//Console.WriteLine(result41);
//Console.WriteLine(result42);

//var inputDay5 = parser.Fetch("day05.txt")
//                      .ToList();


//var result51 = Day5.Part1(inputDay5);
//var result52 = Day5.Part2(inputDay5);

//Console.WriteLine(result51);
//Console.WriteLine(result52);

//var inputDay6 = parser.Fetch("day06.txt")
//                      .ToList();


//var result61 = Day6.Part1(inputDay6, 80);
//var result62 = Day6.Part2(inputDay6, 256);

//Console.WriteLine(result61);
//Console.WriteLine(result62);

//var inputDay7 = parser.Fetch("day07.txt")
//                      .ToList();


//var result71 = Day7.Part1(inputDay7);
//var result72 = Day7.Part2(inputDay7);

//Console.WriteLine(result71);
//Console.WriteLine(result72);

//var inputDay8 = parser.Fetch("day08.txt")
//                      .ToList();


//var result81 = Day8.Part1(inputDay8);
//var result82 = Day8.Part2(inputDay8);

//Console.WriteLine(result81);
//Console.WriteLine(result82);


Console.WriteLine("END");