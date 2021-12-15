module Lib

let lineToPoints (input: string) =
  let parts = input.Split(" -> ")
  let x1y1 = Array.map int (parts.[0].Split(","))
  let x2y2 = Array.map int (parts.[1].Split(","))
  ((x1y1.[0], x1y1.[1]), (x2y2.[0], x2y2.[1]))

let onlyStraight x =
  fst (fst x) = fst (snd x)
  || snd (fst x) = snd (snd x) // x1 = x2 || y1 = y2


let swapIfNegative d a b = if d > 0 then (b, a) else (a, b)

let tupleToArray (tuple: (int * int) * (int * int)) =
  let x1, y1 = fst tuple
  let x2, y2 = snd tuple

  match x1 - x2, y1 - y2 with
  | dx, 0 ->
    let x1, x2 = swapIfNegative dx x1 x2
    [ for x in x1 .. x2 -> (x, y1) ]
  | 0, dy ->
    let y1, y2 = swapIfNegative dy y1 y2
    [ for y in y1 .. y2 -> (x1, y) ]
  | dx, dy ->
    match dx > 0, dy > 0 with
    | true, true -> [ for i in 0 .. dx -> (x2 + i, y2 + i) ]
    | false, true -> [ for i in 0 .. dy -> (x2 - i, y2 + i) ]
    | true, false -> [ for i in 0 .. dx -> (x2 + i, y2 - i) ]
    | false, false -> [ for i in 0 .. -dx -> (x2 - i, y2 - i) ]

let linesToPoints input = input |> List.map lineToPoints

let byGreaterThanOne x = x > 1

let getOverlaps =
  List.map tupleToArray
  >> List.concat
  >> List.countBy id
  >> List.filter (snd >> byGreaterThanOne)
  >> List.length

let totalOverlapsStraight (input: string list) =
  input
  |> List.map lineToPoints
  |> List.filter onlyStraight
  |> getOverlaps


let totalOverlaps input =
  input
  |> List.map lineToPoints
  |> getOverlaps
