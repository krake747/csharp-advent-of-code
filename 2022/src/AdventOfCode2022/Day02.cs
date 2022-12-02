using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day02 : IDayEnumerable
{ 
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(code => Decrypt(code, ShapeDecrypter, ShapeDecrypter))
            .Sum(Score);
    }

    public int Part2(IEnumerable<string> input)
    {
        var x = input.Select(code => Decrypt(code, ShapeDecrypter, OutcomeDecrypter)).Select(Score);
        return input.Select(code => Decrypt(code, ShapeDecrypter, OutcomeDecrypter))
            .Sum(Score);
    }
    
    private static (TL, TR) Decrypt<TL, TR>(string code, 
        Func<char, TL> leftDecrypter, 
        Func<char, TR> rightDecrypter)
    {
        var span = code.AsSpan();
        return (leftDecrypter(span[0]), rightDecrypter(span[^1]));
    }
    
    private static (TL, TR) Decrypt<TL, TR>(string code, 
        Func<char, TL> leftDecrypter, 
        Func<char, char, TR> rightDecrypter)
    {
        var span = code.AsSpan();
        return (leftDecrypter(span[0]), rightDecrypter(span[0], span[^1]));
    }

    private static Shape ShapeDecrypter(char character)
    {
        return character switch
        {
            'A' or 'X' => Shape.Rock,
            'B' or 'Y' => Shape.Paper,
            'C' or 'Z' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(character), "Matching pattern is not defined")
        };
    }
    
    private static Shape OutcomeDecrypter(char leftCharacter, char rightCharacter)
    {
        var winCondition = rightCharacter switch
        {
            'X' => Outcome.Lose,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(rightCharacter), "Matching pattern is not defined")
        };
        
        var losesTo = new Dictionary<Shape, Shape>
        {
            { Shape.Paper, Shape.Rock },
            { Shape.Rock, Shape.Scissors },
            { Shape.Scissors, Shape.Paper },
        };

        var leftShape = ShapeDecrypter(leftCharacter);
        return winCondition switch
        {
            Outcome.Draw => leftShape,
            Outcome.Lose => losesTo[leftShape],
            _ => losesTo.First(shape => shape.Value == leftShape).Key
        };
    }



    private static int Score((Shape, Shape) shapes)
    {
        var (left, right) = shapes;
        return left == right
            ? (int)right + (int)Outcome.Draw
            : (int)right + (left, right) switch
            {
                (Shape.Rock, Shape.Paper) => (int)Outcome.Win,
                (Shape.Paper, Shape.Scissors) => (int)Outcome.Win,
                (Shape.Scissors, Shape.Rock) => (int)Outcome.Win,
                (_, _) => (int)Outcome.Lose
            };
    }
}

public enum Shape
{
    Rock = 1,
    Paper,
    Scissors
}

public enum Outcome
{
    Lose = 0,
    Draw = 3,
    Win = 6
}