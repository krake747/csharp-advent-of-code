using System.Linq;
using System.Text.RegularExpressions;

using AdventOfCode2021.Shared;

namespace AdventOfCode2021;

public static class Day4
{
    public static int Part1(IEnumerable<string> input)
    {
        var bingoSystem = ProcessInput(input);
        var score = BingoScore(bingoSystem);
        return score;
    }

    public static int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    internal static BingoSystem ProcessInput(IEnumerable<string> input)
    {
        var numbers = input.First().Split(',');

        var boards = new List<string[][]> { };
        var board = new List<string[]> { };
        foreach (var row in input.Skip(2).Append(""))
        {
            if (string.IsNullOrEmpty(row))
            {
                boards.Add(board.ToArray());
                board.Clear();
                continue;
            }

            board.Add(row.Split(' ').Where(s => s != "").ToArray());
        }

        return new BingoSystem(numbers, boards);
    }

    internal static int BingoScore(BingoSystem bingoSystem)
    {
        foreach (var number in bingoSystem.Numbers)
        {
            MarkNumber(bingoSystem, number);
            
            var winningBoard = HasBingo(bingoSystem);

            if (winningBoard.Bingo)
            {
                return CalculateBingoScore(winningBoard, number);
            }  
        }

        return -1;
    }

    private static void MarkNumber(BingoSystem bingoSystem, string number)
    {
        foreach (var (board, index) in bingoSystem.Boards.ToList().WithIndex())
        {
            var markedBoard = Enumerable.Range(0, board.GetLength(0))
                                        .Select(r => board[r].Select(x => Regex.Replace(x, @$"^{number}$", "X")).ToArray())
                                        .ToArray();

            bingoSystem.Boards.Remove(board);
            bingoSystem.Boards.Insert(index, markedBoard);
        }
    }

    private static WinningBoard HasBingo(BingoSystem bingoSystem)
    {
        foreach (var (board, index) in bingoSystem.Boards.ToList().WithIndex())
        {
            var checkCols = Enumerable.Range(0, board.GetLength(0))
                                      .Select(c => board.GetColumn(c).All(v => v == "X"))
                                      .Any(c => c == true);

            var checkRows = Enumerable.Range(0, board.GetLength(0))
                                      .Select(r => board.GetRow(r).All(v => v == "X"))
                                      .Any(r => r == true);
            
            if (checkCols || checkRows) return new WinningBoard(true, board, index);
        }

        return new WinningBoard(false, new string[][] {}, -1);
    }

    private static int CalculateBingoScore(WinningBoard board, string number)
    {
        var unmarkedScore = board.Board.Select(r => r.Where(v => v != "X").Sum(int.Parse))
                                 .Sum();

        return unmarkedScore * int.Parse(number);
    }

    internal record BingoSystem(string[] Numbers, List<string[][]> Boards);
    internal record WinningBoard(bool Bingo, string[][] Board, int Index);
}