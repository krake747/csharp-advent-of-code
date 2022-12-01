namespace AdventOfCodeLib;

internal interface IFileParserService
{
    IEnumerable<string> Fetch(string path);
}