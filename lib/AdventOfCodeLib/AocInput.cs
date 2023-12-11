namespace AdventOfCodeLib;

public sealed class AocInput
{
    public required string Text { get; init; }
    public required IEnumerable<string> Lines { get; init; }
    
    public required string[] AllLines { get; init; }
}