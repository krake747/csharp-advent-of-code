using AdventOfCode2021;
using AdventOfCode2021.Shared;

var parser = new TextFileParserService();

var input = parser.Fetch("day01.txt")
                  .Select(int.Parse)
                  .ToList();

var result1 = Day1.Part1(input);
var result2 = Day1.Part2(input);

Console.WriteLine(result1);
Console.WriteLine(result2);