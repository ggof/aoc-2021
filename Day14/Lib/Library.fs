module Day14

let updateMapEntry value =
  Option.defaultValue (int64 0) >> (+) value >> Some

let produceNewElementMap (transforms: Map<char array, char>) (acc: Map<char array, int64>) key value =
  let newLetter = Map.find key transforms
  
  acc
  |> Map.change [| key.[0]; newLetter |] (updateMapEntry value)
  |> Map.change [| newLetter; key.[1] |] (updateMapEntry value)

let foldToNewMap transforms =
  Map.fold (produceNewElementMap transforms) Map.empty

let rec iterations i element transforms =
  match i with
  | 0 -> element
  | _ -> iterations (i - 1) (foldToNewMap transforms element) transforms

let elementToMap (element: string) =
  let toMap acc cur = Map.change cur (updateMapEntry (int64 1)) acc

  element.ToCharArray()
  |> Array.windowed 2
  |> Array.fold toMap Map.empty

let transformsFromString (input: string array) =
  let toTransforms map (elem: string) =
    let parts = elem.Split(" -> ")
    Map.add (parts.[0].ToCharArray()) parts.[1].[0] map

  input
  |> Array.filter (fun x -> x.Length > 0)
  |> Array.fold toTransforms Map.empty

let parseInput (input: string) =
  let parts = input.Split("\n\n")
  (elementToMap parts.[0]), (transformsFromString (parts.[1].Split("\n")))
