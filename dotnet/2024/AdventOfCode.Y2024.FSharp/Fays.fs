namespace AdventOfCode.Y2024.FSharp

open AdventOfCode.Lib

module Fay01 =

    let instructions (lines: string seq) (col: int) =
        lines
        |> Seq.map (fun line -> line.Split("   ") |> Array.map int)
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
