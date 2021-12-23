module Day13

open System

type Fold =
  | Vertical of int
  | Horizontal of int

let verticalFold pos (x, y) =
  if y > pos then
    (x, (2 * pos) - y)
  else
    x, y

let horizontalFold pos (x, y) =
  if x > pos then
    ((2 * pos) - x, y)
  else
    x, y

let fold direction points =
  match direction with
  | Vertical pos -> Set.map (verticalFold pos) points
  | Horizontal pos -> Set.map (horizontalFold pos) points

let rec foldAll points folds =
  match folds with
  | [] -> points
  | hd :: tl -> foldAll (fold hd points) tl
  
let pointsFromString (input: string) =
  let toTuple (x: string) =
    let parts = x.Split(",")
    (int parts.[0], int parts.[1])

  input.Split("\n")
  |> Array.map toTuple
  |> Set.ofArray

let foldsFromString (input: string) =
  let toFold (x: string) =
    let parts = x.Split("=")

    match parts.[0].EndsWith('x') with
    | true -> Fold.Horizontal(int parts.[1])
    | false -> Fold.Vertical(int parts.[1])

  input.Split("\n")
  |> Array.filter (fun x -> x.Length > 0)
  |> Array.map toFold
  |> List.ofArray
