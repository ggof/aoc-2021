namespace Day3


module Lib =
  open System

  let max s =
    let rec getMax lst cur =
      match lst with
      | [] -> cur
      | hd :: tl ->
        match hd with
        | k, v when v > snd (cur) -> getMax tl hd
        | '1', v when v = snd (cur) -> getMax tl hd
        | _ -> getMax tl cur

    getMax s ('0', 0)

  let findMostCommonAt input pos =
    let charAt pos (str: string) = str.[pos]

    input
    |> Seq.countBy (charAt pos)
    |> Seq.toList
    |> max
    |> fst

  let findLeastCommonAt input pos =
    findMostCommonAt input pos
    |> fun x -> if x = '0' then '1' else '0'

  let findGamma input =
    input
    |> Seq.transpose
    |> Seq.map (Seq.countBy id >> Seq.maxBy snd)
    |> Seq.map fst
    |> Seq.toArray
    |> String

  let findEpsilon gamma =
    String.map (fun x -> if x = '1' then '0' else '1') gamma

  let binaryToInt (value: string) =
    let toInteger i v = if v = '1' then 1 <<< i else 0
    value |> Seq.rev |> Seq.mapi toInteger |> Seq.sum


  let calculateRating gamma epsilon = binaryToInt gamma * binaryToInt epsilon

  let findO2Rating (input: seq<string>) =
    let rec findO2Position (input: list<string>) (pos: int) =
      let gamma = findMostCommonAt (Seq.ofList input) pos

      let result =
        input |> List.filter (fun x -> x.[pos] = gamma)

      match result with
      | [ hd ] -> hd
      | _ -> findO2Position result (pos + 1)

    findO2Position (Seq.toList input) 0

  
  let findCO2Rating (input: seq<string>) =
    let rec findCO2Position (input: list<string>) (pos: int) =
      let leastCommon = findLeastCommonAt (Seq.ofList input) pos

      let result =
        input |> List.filter (fun x -> x.[pos] = leastCommon)

      match result with
      | [ hd ] -> hd
      | _ -> findCO2Position result (pos + 1)

    findCO2Position (Seq.toList input) 0
