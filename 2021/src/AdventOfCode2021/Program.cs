using AdventOfCode2021;
using AdventOfCode2021.Shared;

var parser = new TextFileParserService();

var input = parser.Fetch("day01.txt")
                  .Select(int.Parse)
                  .ToArray();

var result = Day1.Function(input);

Console.WriteLine(result);