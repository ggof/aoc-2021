open System.IO

let toInt [| a; b |] = if a >= b then 0 else 1

let calculateTotal =
  Seq.windowed 2 >> Seq.map toInt >> Seq.sum

let calculateTotalWindowed =
  Seq.windowed 3
  >> (Seq.map Seq.sum<int>)
  >> calculateTotal

[<EntryPoint>]
let main args =
  let numbers =
    [| 199
       200
       208
       210
       200
       207
       240
       269
       260
       263 |]

  let total =
    File.ReadAllLines "input.txt"
    |> Seq.map int
    |> calculateTotalWindowed

  printfn $"the total is {total}"
  0
