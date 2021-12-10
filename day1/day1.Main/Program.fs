open System.IO

let printResult i = printfn $"total: {i}"

[<EntryPoint>]
let main args =
  args
  |> Array.head
  |> File.ReadAllLines
  |> Seq.map int
  |> day1.Lib.calculateTotalWindowed
  |> printResult

  0
