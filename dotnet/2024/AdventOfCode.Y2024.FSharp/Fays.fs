﻿namespace AdventOfCode.Y2024.FSharp

open System.Text.RegularExpressions
open AdventOfCode.Lib

module Fay01 =

    let instructions (lines: string seq) (col: int) =
        lines
        |> Seq.map (fun line -> line.Split "   " |> Array.map int)
        |> Seq.sortBy (fun nums -> nums[col])
        |> Seq.map (fun nums -> nums[col])

    let part1 (input: AocInput) =
        let column = instructions input.Lines
        let left = column 0
        let right = column 1

        Seq.zip left right |> Seq.map (fun x -> abs (fst x - snd x)) |> Seq.sum

    let part2 (input: AocInput) =
        let column = instructions input.Lines
        let left = column 0
        let counts = column 1 |> Seq.countBy id |> Map.ofSeq

        let getCount id =
            Map.tryFind id counts |> Option.defaultValue 0

        left |> Seq.sumBy (fun id -> getCount id * id)

module Fay02 =

    let instructions (lines: string seq) : int array seq =
        lines |> Seq.map (fun line -> line.Split ' ' |> Array.map int)

    let monotonicIncreasing (pairs: (int * int) array) : bool =
        pairs
        |> Array.forall (fun (left, right) -> 1 <= right - left && right - left <= 3)

    let monotonicDecreasing (pairs: (int * int) array) : bool =
        pairs
        |> Array.forall (fun (left, right) -> 1 <= left - right && left - right <= 3)

    let monotonic (instructions: int array) =
        let left = instructions |> Array.take (instructions.Length - 1)
        let right = instructions |> Array.skip 1
        let pairs = Array.zip left right

        (monotonicIncreasing pairs) || (monotonicDecreasing pairs)

    let problemDampener (instructions: int array) : int array seq =
        seq {
            for i in 0 .. instructions.Length do
                let take = instructions |> Seq.take (max 0 (i - 1))
                let skip = instructions |> Seq.skip i
                yield Seq.append take skip |> Seq.toArray
        }

    let part1 (input: AocInput) : int =
        input.Lines |> instructions |> Seq.filter monotonic |> Seq.length

    let part2 (input: AocInput) : int =
        input.Lines
        |> instructions
        |> Seq.filter (fun instruction -> problemDampener instruction |> Seq.exists monotonic)
        |> Seq.length

module Fay03 =

    [<Struct>]
    type State = { Enabled: bool; Total: int64 }

    let instructions (m: Match) : int64 =
        int64 (m.Groups[1].Value) * int64 (m.Groups[2].Value)

    let conditionalInstructions (state: State) (m: Match) =
        match m.Value with
        | "do()" -> { state with Enabled = true }
        | "don't()" -> { state with Enabled = false }
        | _ when state.Enabled -> { state with Total = state.Total + instructions m }
        | _ -> state

    let part1 (input: AocInput) : int64 =
        input.Text |> Regex(@"mul\((\d+),(\d+)\)").Matches |> Seq.sumBy instructions

    let part2 (input: AocInput) : int64 =
        input.Text
        |> Regex(@"do\(\)|don't\(\)|mul\((\d+),(\d+)\)").Matches
        |> Seq.fold conditionalInstructions { Enabled = true; Total = 0 }
        |> _.Total
