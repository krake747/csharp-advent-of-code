namespace AdventOfCode.Y2024.FSharp

open System.Text.RegularExpressions
open AdventOfCode.Lib

[<AocPuzzle(2024, 1, "Historian Hysteria", "F#")>]
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

[<AocPuzzle(2024, 2, "Red-Nosed Reports", "F#")>]
module Fay02 =

    let instructions (lines: string seq) =
        lines |> Seq.map (fun line -> line.Split ' ' |> Array.map int)

    let monotonicIncreasing (pairs: (int * int) array) =
        pairs
        |> Array.forall (fun (left, right) -> 1 <= right - left && right - left <= 3)

    let monotonicDecreasing (pairs: (int * int) array) =
        pairs
        |> Array.forall (fun (left, right) -> 1 <= left - right && left - right <= 3)

    let monotonic (instructions: int array) =
        let left = instructions |> Array.take (Array.length instructions - 1)
        let right = instructions |> Array.skip 1
        let pairs = Array.zip left right

        (monotonicIncreasing pairs) || (monotonicDecreasing pairs)

    let problemDampener (instructions: int array) =
        seq {
            for i in 0 .. Array.length instructions do
                let take = instructions |> Seq.take (max 0 (i - 1))
                let skip = instructions |> Seq.skip i
                yield Seq.append take skip |> Seq.toArray
        }

    let part1 (input: AocInput) =
        input.Lines |> instructions |> Seq.filter monotonic |> Seq.length

    let part2 (input: AocInput) =
        input.Lines
        |> instructions
        |> Seq.filter (fun instruction -> problemDampener instruction |> Seq.exists monotonic)
        |> Seq.length

[<AocPuzzle(2024, 3, "Mull It Over", "F#")>]
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

[<AocPuzzle(2024, 4, "Ceres Search", "F#")>]
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
            for x, c in line |> Seq.toArray |> Array.indexed -> { X = x; Y = y }, c
        |])
        |> Map.ofArray

    let searchWord (map: Map<Point, char>) (pattern: string) (p: Point) (dir: Point) =
        let chars = [
            for i in 0 .. pattern.Length - 1 -> map.TryFind(p + dir * i) |> Option.defaultValue ' '
        ]

        chars = Seq.toList pattern || chars = Seq.toList (Seq.rev pattern)

    let searchXmas (map: Map<Point, char>) =
        let directions = [ Point.East; Point.SouthEast; Point.South; Point.SouthWest ]
        let searchMapForXmas = searchWord map "XMAS"

        map.Keys
        |> Seq.collect (fun p -> directions |> Seq.map (searchMapForXmas p))
        |> Seq.filter id

    let searchXmasShape (map: Map<Point, char>) =
        let searchMapForXmasShape = searchWord map "MAS"

        map.Keys
        |> Seq.filter (fun p ->
            searchMapForXmasShape (p + Point.NorthWest) Point.SouthEast
            && searchMapForXmasShape (p + Point.SouthWest) Point.NorthEast)

    let part1 (input: AocInput) =
        input.AllLines |> parseMap |> searchXmas |> Seq.length

    let part2 (input: AocInput) =
        input.AllLines |> parseMap |> searchXmasShape |> Seq.length

[<AocPuzzle(2024, 5, "Print Queue", "F#")>]
module Fay05 =

    type Pages = string array
    type PageUpdates = string array array
    type PagePrecedenceRules = System.Collections.Generic.Comparer<string>

    type SafetyManual = {
        Updates: PageUpdates
        PrecedenceRules: PagePrecedenceRules
    }

    let sleighLaunchSafetyManual (text: string) =
        let parts = text.Split("\n\n")
        let ordering = parts[0].Split('\n') |> Set.ofArray
        let updates = parts[1].Split('\n') |> Array.map _.Split(',')

        let precedenceRules =
            PagePrecedenceRules.Create(fun p1 p2 -> if ordering.Contains $"%s{p1}|%s{p2}" then -1 else 1)

        { Updates = updates; PrecedenceRules = precedenceRules }

    let elfPageSorting (precedenceRules: PagePrecedenceRules) (pages: Pages) =
        pages = Array.sortWith (fun p1 p2 -> precedenceRules.Compare(p1, p2)) pages

    let extractMiddlePage (pages: Pages) = int pages[Array.length pages / 2]

    let part1 (input: AocInput) =
        input.Text
        |> sleighLaunchSafetyManual
        |> fun manual ->
            manual.Updates
            |> Array.filter (elfPageSorting manual.PrecedenceRules)
            |> Array.sumBy extractMiddlePage


    let part2 (input: AocInput) =
        input.Text
        |> sleighLaunchSafetyManual
        |> fun manual ->
            manual.Updates
            |> Array.filter (fun pages -> not (elfPageSorting manual.PrecedenceRules pages))
            |> Array.map (Array.sortWith (fun p1 p2 -> manual.PrecedenceRules.Compare(p1, p2)))
            |> Array.sumBy extractMiddlePage

[<AocPuzzle(2024, 6, "Guard Gallivant", "F#")>]
module Fay06 =

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
        static member RotationClockwise90 = { X = 0; Y = 1 }
        static member (+)(p1: Point, p2: Point) = { X = p1.X + p2.X; Y = p1.Y + p2.Y }

        static member (*)(p1: Point, p2: Point) = {
            X = p1.X * p2.X - p1.Y * p2.Y
            Y = p1.X * p2.Y + p1.Y * p2.X
        }

        static member (*)(p: Point, factor: int) = { X = p.X * factor; Y = p.Y * factor }
        static member rotateRight(p: Point) = p * Point.RotationClockwise90

    type PatrolMap = Map<Point, char>
    type Positions = Set<Point>

    type PatrolState = { Position: Point; Direction: Point }

    type GuardRoute = { Positions: Positions; Loop: bool }

    let parsePatrolMap (lines: string array) =
        lines
        |> Array.indexed
        |> Array.collect (fun (y, line) -> [|
            for x, c in line |> Seq.toArray |> Array.indexed -> { X = x; Y = y }, c
        |])
        |> Map.ofArray

    let locateGuardStart (map: PatrolMap) (c: char) =
        map |> Seq.find (fun kvp -> kvp.Value = c) |> _.Key

    let trackGuardRoute (map: PatrolMap) (start: Point) =
        let mutable position = start
        let mutable patrol = { Position = start; Direction = Point.North }
        let visited = System.Collections.Generic.HashSet<PatrolState>()

        while map.ContainsKey patrol.Position && visited.Add patrol do
            patrol <-
                match map.TryFind(patrol.Position + patrol.Direction) |> Option.defaultValue ' ' with
                | '#' -> {
                    patrol with
                        Direction = Point.rotateRight patrol.Direction
                  }
                | _ ->
                    position <- position + patrol.Direction
                    { patrol with Position = position }

        {
            Positions = visited |> Seq.map _.Position |> Set.ofSeq
            Loop = visited.Contains patrol
        }

    let updateMap (map: PatrolMap) (obstacle: char) (position: Point) =
        map |> Map.map (fun key value -> if key = position then obstacle else value)

    let part1 (input: AocInput) =
        input.AllLines
        |> parsePatrolMap
        |> (fun m -> (m, locateGuardStart m '^'))
        |> (fun (map, start) -> trackGuardRoute map start)
        |> _.Positions
        |> Set.count

    let part2 (input: AocInput) =
        let map = parsePatrolMap input.AllLines
        let start = locateGuardStart map '^'
        let route = trackGuardRoute map start

        route
        |> _.Positions
        |> Set.filter (fun p -> map[p] = '.')
        |> Seq.sumBy (fun obstacle ->
            let updatedMap = updateMap map '#' obstacle
            let route = trackGuardRoute updatedMap start
            route |> _.Loop |> (fun loop -> if loop then 1 else 0))
