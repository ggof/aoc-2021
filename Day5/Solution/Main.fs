module Main
// For more information see https://aka.ms/fsharp-console-apps

open System.IO

[<EntryPoint>]
let main argv =
  let lines =
    Array.head argv
    |> (File.ReadAllLines >> List.ofArray)
    
  let nbStraight = Lib.totalOverlapsStraight lines
  let nbTotal = Lib.totalOverlaps lines

  printfn $"number of overlapping lines (straight lines): {nbStraight}"
  printfn $"number of overlapping lines (total): {nbTotal}"

  0
