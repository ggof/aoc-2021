module Day4.Solution

open System.IO


[<EntryPoint>]
let main args =
  let text = File.ReadAllText(Seq.head args)
  let result =
    text
    |> Lib.ofString
    |> fun (moves, grids) -> Lib.play moves grids
    
  let nbMoves (x: Lib.Grid) = x.nbMoves
    
  let firstWinner = result (List.minBy nbMoves)
  let lastWinner = result (List.maxBy nbMoves)

  printfn $"first winner: {firstWinner}"
  printfn $"last winner: {lastWinner}"
  0
