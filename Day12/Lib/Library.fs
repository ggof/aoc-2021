module Lib

open System

type Size =
  | Small
  | Large

type Cave =
  { name: string
    size: Size
    mutable neighbours: Cave list }

let toCave name _ =
  { name = name
    size =
      (if String.forall Char.IsUpper name then
         Size.Large
       else
         Size.Small)
    neighbours = [] }

let private byName a b = a.name = b.name

let private oneIfEnd current =
  match current.name with
  | "end" -> Some(1)
  | "start" -> Some(0)
  | _ -> None

let rec private dfs lives path current =
  let recurse () =
    match current.size with
    | Small ->
      path
      |> Set.contains current.name
      |> fun inSet ->
           match inSet, lives with
           | true, 0 -> 0
           | true, _ -> List.sumBy (dfs (lives - 1) path) current.neighbours
           | false, _ -> List.sumBy (dfs lives (Set.add current.name path)) current.neighbours
    | Large -> List.sumBy (dfs lives path) current.neighbours

  current |> oneIfEnd |> Option.defaultWith recurse

let numberOfPaths lives start =
  List.sumBy (dfs lives (Set.add "start" Set.empty)) start.neighbours

let private addToSet value =
  Option.defaultValue Set.empty
  >> Set.add value
  >> Some

let private intoSet acc (a, b) =
  acc
  |> Map.change a (addToSet b)
  |> Map.change b (addToSet a)

let private toTuple (x: string) =
  let parts = x.Split("-")
  (parts.[0], parts.[1])

let private updateNeighbours caves k v =
  let update cave =
    cave.neighbours <- [ for name in v -> Map.find name caves ]

  caves |> Map.find k |> update

let fromString lives (str: string) =
  let segments =
    str.Split("\n")
    |> Array.filter (String.IsNullOrEmpty >> not)
    |> Array.map toTuple

  let m = Array.fold intoSet Map.empty segments
  let caves = Map.map toCave m

  // DIRTY hack since creating a graph is hard
  Map.iter (updateNeighbours caves) m

  numberOfPaths lives (Map.find "start" caves)
