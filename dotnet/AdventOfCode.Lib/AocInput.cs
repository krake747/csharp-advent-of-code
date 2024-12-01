namespace AdventOfCode.Lib;

public sealed record AocInput(
    string Text, 
    IEnumerable<string> Lines, 
    string[] AllLines
);