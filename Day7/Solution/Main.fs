module Main

open System.IO

[<EntryPoint>]
let main argv =
  let input = argv |> Array.head |> File.ReadAllText

  let part1 =
    task {
      let! pos, fuel = Lib.lowestFuelSubstract input
      printfn $" lowest position problem 1: {pos} with {fuel} units"
    }

  let part2 =
    task {
      let! pos, fuel = Lib.lowestFuelIncremental input
      printfn $" lowest position problem 2: {pos} with {fuel} units"
    }

  [ part1; part2 ]
  |> List.map Async.AwaitTask
  |> Async.Parallel
  |> Async.RunSynchronously
  |> ignore

  0
