using Xunit.Abstractions;

namespace AdventOfCode.Lib;

public sealed class AocInput: IXunitSerializable
{
    public required string Text { get; set; }
    public required IEnumerable<string> Lines { get; set; }
    public required string[] AllLines { get; set; }
    public void Deserialize(IXunitSerializationInfo info)
    {
        Text = info.GetValue<string>(nameof(Text));
        AllLines = info.GetValue<string[]>(nameof(AllLines));
        Lines = AllLines.AsEnumerable();
    }

    public void Serialize(IXunitSerializationInfo info)
    {
        info.AddValue(nameof(Text), Text);
        info.AddValue(nameof(AllLines), AllLines);
    }
}