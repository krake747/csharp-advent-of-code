using AdventOfCode.Lib;
using Spectre.Console;

var aocDays = AocDayFinder.FindAocSolvers();

foreach (var aocDay in aocDays.Keys)
{
    AnsiConsole.WriteLine(aocDays[aocDay].ToString());
    // AocFileReader.ReadInput("");

    var solver = Activator.CreateInstance(aocDays[aocDay]) as IAocSolver;
    var partOne = solver?.PartOne(new AocInput("", [], []));
    var partTwo = solver?.PartOne(new AocInput("", [], []));
}