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

var inputDay2 = parser.Fetch("day02.txt")
                      .ToList();

var result21 = Day2.Part1(inputDay2, 0, 0);


Console.WriteLine("END");
