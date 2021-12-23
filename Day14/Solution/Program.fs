open System.IO

[<EntryPoint>]
let main argv =
  let element, transforms =
    argv
    |> Array.head
    |> File.ReadAllText
    |> Day14.parseInput
  
  let i = argv |> Array.last |> int

  let element = Day14.iterations i element transforms
  
  let diff = Day14.diffMostLeast element
  
  printfn $"diff: {diff}"

  0
