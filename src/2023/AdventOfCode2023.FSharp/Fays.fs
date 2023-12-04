namespace AdventOfCode2023.FSharp

open System.Text.RegularExpressions
open AdventOfCodeLib

module Fays =
    let calibration (mc: MatchCollection) =
        match mc |> Seq.toList with
        | [ digit ] -> $"{digit}{digit}"
        | head :: tail -> $"{head}{List.last tail}"
        | _ -> failwith "Unreachable"

    let part1 (input: AocInput) =
        input.Lines
        |> Seq.toList
        |> List.map (fun x -> Regex.Matches(x, @"\d"))
        |> List.sumBy (calibration >> int)

    let part2 (input: AocInput) =
        input.Lines
        |> Seq.toList
        |> List.map (
            _.Replace("one", "o1e")
                .Replace("two", "t2o")
                .Replace("three", "t3e")
                .Replace("four", "f4r")
                .Replace("five", "f5e")
                .Replace("six", "s6x")
                .Replace("seven", "s7n")
                .Replace("eight", "e8t")
                .Replace("nine", "n9e")
        )
        |> List.map (fun x -> Regex.Matches(x, @"\d"))
        |> List.sumBy (calibration >> int)

module Fay02 =
    [<Struct>]
    type Bag = { Id: int; Red: int; Green: int; Blue: int }

    let countCubesInBag (game: string) =
        let countCubes (game: string) (regex: Regex) =
            regex.Matches(game)
            |> Seq.toList
            |> List.map (fun x -> int x.Groups[1].Value)
            |> List.max

        let countColour = countCubes game
        let id = int Regex.Match(game, @"Game (\d+)").Groups[1].Value 
        let red = countColour (Regex @"(\d+) red")
        let green = countColour (Regex @"(\d+) green")
        let blue = countColour (Regex @"(\d+) blue")
        { Id = id; Red = red; Green = green; Blue = blue }

    let playGame1 (game: string) =
        countCubesInBag game
        |> (fun bag -> if bag.Red <= 12 && bag.Green <= 13 && bag.Blue <= 14 then bag.Id else 0)

    let playGame2 (game: string) =
        countCubesInBag game |> (fun bag -> bag.Red * bag.Green * bag.Blue)

    let part1 (input: AocInput) =
        input.Lines |> Seq.toList |> List.sumBy playGame1

    let part2 (input: AocInput) =
        input.Lines |> Seq.toList |> List.sumBy playGame2

module Fay03 =
    [<Struct>]
    type Coordinate = { Row: int; Col: int }
    type Part = { Coordinate: Coordinate; Text: string; OffSet: int }
    
    let parseEngineSchematics (lines: string list) (regex: Regex) =
        seq {
            for row in 0..lines.Length - 1 do
            for m in regex.Matches(lines[row]) do
                yield {
                    Coordinate = { Row = row; Col = m.Index }
                    Text = m.Value
                    OffSet = m.Value.Length
                }
        }
        |> Seq.toList 
    
    let horizontalAdjacent (p1: Part, p2: Part) =
        p2.Coordinate.Col + p2.OffSet >= p1.Coordinate.Col
        
    let verticalAdjacent (p1: Part, p2: Part) =
        abs(p2.Coordinate.Row - p1.Coordinate.Row) <= 1
        
    let adjacent (p1: Part, p2: Part) =
        verticalAdjacent (p1, p2) && horizontalAdjacent (p1, p2) && horizontalAdjacent (p2, p1)
        
    let part1 (input: AocInput) =
        let parseParts = input.Lines |> Seq.toList |> parseEngineSchematics
        let partNumbers = fun number -> int number.Text
        let symbols = parseParts (Regex @"[^.\d]")
        let numbers = parseParts (Regex @"\d+")
        numbers
        |> List.where (fun number -> symbols |> List.exists (fun symbol -> adjacent (number, symbol)))
        |> List.sumBy partNumbers
        

    let part2 (input: AocInput) =
        let parseParts = input.Lines |> Seq.toList |> parseEngineSchematics
        let correctGear = fun neighbors -> List.length neighbors = 2
        let gearRatio = fun (gears: Part list) -> (int gears[0].Text) * (int gears[1].Text)
        let gears = parseParts (Regex @"\*")
        let numbers = parseParts (Regex @"\d+")
        gears
        |> List.map (fun gear -> numbers |> List.where (fun number -> adjacent (number, gear)))
        |> List.where correctGear
        |> List.sumBy gearRatio
