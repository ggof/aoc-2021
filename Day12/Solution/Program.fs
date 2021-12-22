// For more information see https://aka.ms/fsharp-console-apps

open System.IO

[<EntryPoint>]
let main argv =
  let input =
    argv
    |> Array.head
    |> File.ReadAllText
    
  let paths = Lib.fromString 0 input
  printfn $"there are {paths} possible paths with 1 jump"
  
  let paths = Lib.fromString 1 input
  printfn $"there are {paths} possible paths with 2 jump"

  0
