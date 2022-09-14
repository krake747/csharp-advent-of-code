using AdventOfCode2021;
using AdventOfCode2021.Shared;

var parser = new TextFileParserService();

//var inputDay1 = parser.Fetch("day01.txt")
//                  .Select(int.Parse)
//                  .ToList();

//var result1 = Day1.Part1(inputDay1);
//var result2 = Day1.Part2(input);

//Console.WriteLine(result1);
//Console.WriteLine(result2);

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

var inputDay4 = parser.Fetch("day04.txt")
                      .ToList();


var result41 = Day4.Part1(inputDay4);
var result42 = Day4.Part2(inputDay4);

Console.WriteLine(result41);
Console.WriteLine(result42);


Console.WriteLine("END");
