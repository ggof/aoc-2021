open System.IO

[<EntryPoint>]
let main argv =
  let text = argv |> Array.head |> File.ReadAllText
  let parts = text.Split("\n\n")

  let points = Day13.pointsFromString parts.[0]
  let folds = Day13.foldsFromString parts.[1]

  let foldedOnce = Day13.fold (List.head folds) points
  printfn $"total points after 1 fold: {foldedOnce |> Set.count}"

  let folded =
    Day13.foldAll foldedOnce (List.tail folds)

  let maxX =
    folded |> Set.toList |> List.maxBy fst |> fst

  let maxY =
    folded |> Set.toList |> List.maxBy snd |> snd

  for y in 0 .. maxY + 1 do
    for x in 0 .. maxX + 1 do
      if Set.contains (x, y) folded then
        printf "█"
      else
        printf " "

    printfn ""

  0
