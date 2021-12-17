module Lib

let incrementalFuel pos cur =
  let rec loop i acc next =
    match i with
    | 0 -> acc
    | _ -> loop (i - 1) (acc + next) (next + 1)

  loop (abs (pos - cur)) 0 1

let toFuelConsumed mapper pos acc cur = acc + abs (mapper pos cur)

let toFuelConsumedTuple mapper (input: int []) (pos: int) =
  let fuelConsumed =
    Array.fold (toFuelConsumed mapper pos) 0 input

  pos, fuelConsumed

let lowestFuel mapper (inputString: string) =
  task {


    let input = inputString.Split(",") |> Array.map int

    let everyIndex max =
      [ for i in 0 .. max ->
          task { return toFuelConsumedTuple mapper input i }
          |> Async.AwaitTask ]
      |> Async.Parallel

    let! values = input |> Array.max |> everyIndex
    return Array.minBy snd values
  }

let lowestFuelSubstract = lowestFuel (-)
let lowestFuelIncremental = lowestFuel incrementalFuel
