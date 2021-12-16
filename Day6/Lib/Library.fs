module Lib.Fishes

let ofString (input: string) =
  input.Split(",") |> Array.map int |> List.ofArray

let private intoCountList fishes =
  let byValue i x = fst x = i

  let fishOrDefault i =
    fishes
    |> List.tryFind (byValue i)
    |> Option.map (snd >> int64)
    |> Option.defaultValue 0L

  List.init 9 fishOrDefault

let private initFishCounter input =
  input
  |> ofString
  |> List.countBy id
  |> intoCountList

let nextDay counts =
  let addTo6th value index current =
    match index with
    | 6 -> value + current
    | _ -> current

  match counts with
  | [] -> []
  | head :: tail ->
    List.append tail [ head ]
    |> List.mapi (addTo6th head)

let rec afterDays days counts =
  match days with
  | 1 -> counts |> nextDay
  | _ -> counts |> nextDay |> afterDays (days - 1)

let totalAfterDays days input : int64 =
  input
  |> initFishCounter
  |> afterDays days
  |> List.sum
