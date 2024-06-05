using Memory = System.Collections.Generic.List<int>;

namespace AdventOfCode.Lib;

public sealed class IntCodeMachine
{
    private readonly Memory _memory = [];
    private Memory Memory => _memory.ToList();
    
    private IntCodeMachine(IEnumerable<int> input) => _memory.AddRange(input);
    
    
    public static IntCodeMachine Init(string input) => new(input.Split(',').Select(int.Parse));

    private static void Noun(Memory memory, int noun) => memory[1] = noun;
    
    private static void Verb(Memory memory, int verb) => memory[2] = verb;
    
    private static int Address(Memory memory, int i) => memory[i];
    
    private static int Opcode(Memory memory, int i) => memory[i] % 100;

    private static int Arg1(Memory memory, int i)
    {
        var mode = memory[i] >= 100 && memory[i] % 1000 - memory[i] % 100 is 100 ? 1 : 0;
        return mode is 0 ? memory[memory[i + 1]] : memory[i + 1];
    }

    private static int Arg2(Memory memory, int i)
    {
        var mode = memory[i] >= 100 && memory[i] % 10000 - memory[i] % 1000 is 1000 ? 1 : 0;
        return mode is 0 ? memory[memory[i + 2]] : memory[i + 2];
    }
    
    public static int Run(IntCodeMachine icm, int? noun = null, int? verb = null, int? input = null)
    {
        var memory = icm.Memory;

        if (noun is not null)
        {
            Noun(memory, noun.Value);
        }

        if (verb is not null)
        {
            Verb(memory, verb.Value);
        }
        
        var address = FunctionalExtensions.Partial<Memory, int, int>(Address, memory);
        var opcode = FunctionalExtensions.Partial<Memory, int, int>(Opcode, memory);
        var arg1 = FunctionalExtensions.Partial<Memory, int, int>(Arg1, memory);
        var arg2 = FunctionalExtensions.Partial<Memory, int, int>(Arg2, memory);

        List<int> output = [];
        var i = 0;
        while (i < memory.Count && memory[i] is not 99)
        {
            switch (opcode(i))
            {
                case 1: // Addition
                    memory[address(i + 3)] = arg1(i) + arg2(i);
                    i += 4;
                    break;
                case 2: // Multiplication
                    memory[address(i + 3)] = arg1(i) * arg2(i);
                    i += 4;
                    break;
                case 3: // Input
                    memory[address(i + 3)] = input ?? 0;
                    i += 2;
                    break;
                case 4: // Output
                    output.Add(memory[address(i + 1)]);
                    Console.WriteLine(string.Join(",", output));
                    i += 2;
                    break;
                case 5: // Jump-If-True
                    if (arg1(i) is not 0)
                    {
                        i = arg2(i);
                        continue;
                    }

                    i += 3;
                    break;
                case 6: // Jump-If-False
                    if (arg1(i) is 0)
                    {
                        i = arg2(i);
                        continue;
                    }

                    i += 3;
                    break;
                case 7: // Less Than
                    memory[address(i + 3)] = arg1(i) < arg2(i) ? 1 : 0;
                    i += 4;
                    break;
                case 8: // Equals
                    memory[address(i + 3)] = arg1(i) == arg2(i) ? 1 : 0;
                    i += 4;
                    break;
                case 99: // Exit
                    break;
                default: // Error
                    throw new Exception($"Invalid Opcode {opcode(i)}");
            }
        }
        
        return input.HasValue ? output[-1] : memory[0];
    }

    public static int GravityAssist(IntCodeMachine icm, int nouns, int verbs)
    {
        for (var n = 0; n < nouns; n++)
        {
            for (var v = 0; v < verbs; v++)
            {
                if (Run(icm, n, v) == 19690720)
                {
                    return 100 * n + v;
                }
            }
        }

        return -1;
    }

    public static int ThermalEnvironmentSupervisionTerminal(IntCodeMachine icm, int id) => 
        Run(icm, input: id);
}