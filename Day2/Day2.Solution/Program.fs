

// For more information see https://aka.ms/fsharp-console-apps

open System.IO
open Day2

let problem1 args =
  Array.head args
  |> File.ReadLines
  |> Seq.toList
  |> Lib.navigate
  |> Lib.multiply
  |> fun nb -> printfn $"multiplied value: {nb}"
  
let problem2 args =
  Array.head args
  |> File.ReadLines
  |> Seq.toList
  |> Lib.navigateWithAim
  |> Lib.multiply
  |> fun nb -> printfn $"multiplied value: {nb}"

  
[<EntryPoint>]
let main args =
  problem1 args
  problem2 args
  0