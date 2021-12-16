module Main

open System.IO
open Lib

[<EntryPoint>]
let main argv =
  let input = argv |> Array.head |> File.ReadAllText
  let fishesAfter80Days = Fishes.totalAfterDays 80 input
  let fishesAfter256Days = Fishes.totalAfterDays 256 input
  
  printfn $"number of fishes after 80 days : {fishesAfter80Days}"
  printfn $"number of fishes after 256 days : {fishesAfter256Days}"
  0