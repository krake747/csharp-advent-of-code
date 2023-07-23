using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCodeLib;

public static partial class AocFileReaderService
{
    public static AocInput ReadInput(string from) => new()
    {
        Text = ReadAsString(from),
        Lines = ReadAsStream(from)
    };

    public static string ReadAsString(string from) => FetchFile(from, TextReader);

    public static IEnumerable<string> ReadAsStream(string from) => FetchFile(from, StreamReader);

    private static T FetchFile<T>(string from, Func<string, T> reader) =>
        reader(Path.Combine(Directory.GetCurrentDirectory(), from));

    private static IEnumerable<string> StreamReader(string path) => File.ReadLines(path, Encoding.UTF8);

    private static string TextReader(string path)
    {
        var result = File.ReadAllText(path, Encoding.UTF8);
        return (MyRegex().Match(result).Success
            ? MyRegex().Replace(result, "\n")
            : result).TrimEnd();
    }

    [GeneratedRegex("\r\n")]
    private static partial Regex MyRegex();
}