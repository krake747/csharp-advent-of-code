namespace AdventOfCode2021.Shared;

internal interface IFileParserService
{
    IEnumerable<string> Fetch(string path);
}
