open System.IO
open Day3

let problem1 args =
  let gamma =
    File.ReadLines(Array.head args) |> Lib.findGamma

  let epsilon = Lib.findEpsilon gamma

  let powerRate = Lib.calculateRating gamma epsilon

  printfn $"power rate: {powerRate}"

let problem2 args =
  let lines = File.ReadLines (Array.head args)
  let o2Rating = Lib.findO2Rating lines
  let co2Rating = Lib.findCO2Rating lines
  let rate = Lib.calculateRating o2Rating co2Rating
  printfn $"life support rate: {rate}"

[<EntryPoint>]
let main args =
  problem2 args
  0
