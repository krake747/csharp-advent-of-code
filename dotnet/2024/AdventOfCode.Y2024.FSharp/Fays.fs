namespace AdventOfCode.Y2024.FSharp

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

module Fay04 =

    [<Struct>]
    type Point = {
        X: int
        Y: int
    } with

        static member North = { X = 0; Y = -1 }
        static member NorthEast = { X = 1; Y = -1 }
        static member East = { X = 1; Y = 0 }
        static member SouthEast = { X = 1; Y = 1 }
        static member South = { X = 0; Y = 1 }
        static member SouthWest = { X = -1; Y = 1 }
        static member West = { X = -1; Y = 0 }
        static member NorthWest = { X = -1; Y = -1 }
        static member (+)(p1: Point, p2: Point) = { X = p1.X + p2.X; Y = p1.Y + p2.Y }
        static member (*)(p: Point, factor: int) = { X = p.X * factor; Y = p.Y * factor }

    let parseMap (lines: string array) : Map<Point, char> =
        lines
        |> Array.indexed
        |> Array.collect (fun (y, line) -> [|
            for x, char in line.ToCharArray() |> Array.indexed -> { X = x; Y = y }, char
        |])
        |> Map.ofArray

    let wordSearch (map: Map<Point, char>) (pattern: string) (p: Point) (dir: Point) =
        let chars = [
            for i in 0 .. pattern.Length - 1 -> map.TryFind(p + dir * i) |> Option.defaultValue ' '
        ]

        chars = Seq.toList pattern || chars = Seq.toList (Seq.rev pattern)

    let wordSearchXmas (map: Map<Point, char>) =
        let directions = [ Point.East; Point.SouthEast; Point.South; Point.SouthWest ]
        let wordSearchOnMapForXmas = wordSearch map "XMAS"

        map.Keys
        |> Seq.collect (fun p -> directions |> Seq.map (wordSearchOnMapForXmas p))
        |> Seq.filter id

    let wordSearchLargeXmas (map: Map<Point, char>) =
        let wordSearchOnMapForLargeXmas = wordSearch map "MAS"

        map.Keys
        |> Seq.filter (fun p ->
            wordSearchOnMapForLargeXmas (p + Point.NorthWest) Point.SouthEast
            && wordSearchOnMapForLargeXmas (p + Point.SouthWest) Point.NorthEast)

    let part1 (input: AocInput) =
        input.AllLines |> parseMap |> wordSearchXmas |> Seq.length

    let part2 (input: AocInput) =
        input.AllLines |> parseMap |> wordSearchLargeXmas |> Seq.length
