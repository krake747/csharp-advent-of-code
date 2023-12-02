namespace AdventOfCode2023.FSharp

open System
open System.Text.RegularExpressions
open AdventOfCodeLib

module Fay1 =
    let calibration (mc: MatchCollection) =
        match mc |> Seq.toList with
        | [ digit ] -> $"{digit}{digit}"
        | head :: tail -> $"{head}{List.last tail}"
        | _ -> failwith "Unreachable"

    let part1 (input: AocInput) =
        input.Lines
        |> Seq.toList
        |> List.map (fun x -> Regex.Matches(x, @"\d"))
        |> List.map (calibration >> Convert.ToInt32)
        |> List.sum

    let part2 (input: AocInput) =
        input.Lines
        |> Seq.toList
        |> List.map (
            _.Replace("one", "one1one")
                .Replace("two", "two2two")
                .Replace("three", "three3three")
                .Replace("four", "four4four")
                .Replace("five", "five5five")
                .Replace("six", "six6six")
                .Replace("seven", "seven7seven")
                .Replace("eight", "eight8eight")
                .Replace("nine", "nine9nine")
        )
        |> List.map (fun x -> Regex.Matches(x, @"\d"))
        |> List.map (calibration >> Convert.ToInt32)
        |> List.sum
