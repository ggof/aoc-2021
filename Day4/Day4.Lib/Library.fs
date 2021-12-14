module Day4.Lib

open System

type Cell = string * bool

type Grid =
  { cols: Cell list list
    lastMove: string
    nbMoves: int
    score: int }

let markCell (value: string) (grid: Grid) : Grid =
  let mark cell =
    if value = fst cell then
      fst cell, true
    else
      cell

  { grid with
      cols = List.map (List.map mark) grid.cols }

let checkColumn column =
  let rec loop col =
    match col with
    | [] -> true // should never happen!
    | [ hd ] -> snd hd
    | hd :: tl -> if snd hd then loop tl else false

  loop column

let checkDiagonals (cols: Cell list list) =
  let len = List.length cols

  let rec loopTopLeftBottomRight i =
    if i >= len then
      false
    else
      snd cols.[i].[i] && loopTopLeftBottomRight (i + 1)

  let rec loopTopRightBottomLeft i =
    if i >= len - 1 then
      false
    else
      snd cols.[len - i - 1].[i]
      && loopTopRightBottomLeft (i + 1)

  loopTopLeftBottomRight 0
  || loopTopRightBottomLeft 0

let winnerGrid grid =
  let winnerColumn = grid.cols |> List.exists checkColumn

  let winnerRow =
    grid.cols
    |> List.transpose
    |> List.exists checkColumn

  let winnerDiag = checkDiagonals grid.cols
  winnerColumn || winnerRow || winnerDiag

let calculateScore (grid: Grid) =
  let toColumnSum acc cur =
    if snd cur then
      acc
    else
      (int (fst cur)) + acc

  let columnScore = List.fold toColumnSum 0
  let toGridSum acc cur = acc + (columnScore cur)
  let sum = List.fold toGridSum 0 grid.cols

  { grid with
      score = (int grid.lastMove) * sum }


let playUntilDone moves grid = 
  let rec loop moves grid i =
    match moves with
    | [] -> raise (Exception("this sucks"))
    | hd :: tl ->
      grid
      |> markCell hd
      |> fun grid ->
           if winnerGrid grid then
             { grid with lastMove = hd; nbMoves = i }
           else
             loop tl grid (i + 1)
             
  loop moves grid 0

let play moves grids pick : int =
  let lastGrid =
    grids
    |> List.map (playUntilDone moves)
    |> List.map calculateScore
    |> List.filter (fun grid -> grid.nbMoves > 0)
    |> pick

  lastGrid.score

let ofString (str: string) =
  let movesString, gridStrings =
    match List.ofArray (str.Split("\n\n")) with
    | [] -> "", []
    | hd :: tl -> hd, tl

  let split (splitter: string) (x: string) = x.Split(splitter)
  let trim (x: string) = x.Trim()
  let notEmpty x = String.length x > 0

  let strToGrid x =
    { cols = List.map (List.map (fun x -> x, false)) x
      nbMoves = 0
      score = 0
      lastMove = "" }

  let toGrid (gridString: string) : Grid =
    gridString.Split("\n")
    |> List.ofArray
    |> List.map (
      split " "
      >> List.ofArray
      >> List.map trim
      >> List.filter notEmpty
    )
    |> List.filter (fun x -> not (List.isEmpty x))
    |> strToGrid

  let moves = movesString.Split(",")
  let grids = List.map toGrid gridStrings
  List.ofArray moves, grids
