module Tests

open Xunit

[<Fact>]
let ``parses input and calculates correctly`` () =
  let input =
    """NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C"""

  let element, transforms = input |> Day14.parseInput

  let output =
    Day14.iterations 10 element transforms
    |> Map.fold
         (fun acc key value ->
           acc
           |> Map.change key.[0] (Day14.updateMapEntry value)
           |> Map.change key.[1] (Day14.updateMapEntry value))
         Map.empty

  let max =
    output |> Map.toList |> List.maxBy snd |> snd

  let min =
    output |> Map.toList |> List.minBy snd |> snd

  let diff = max - min
  Assert.Equal(int64 1588, diff)

[<Fact>]
let ``correctly updates a number`` () =
  let input = Some(int64 10)
  let expected = Some(int64 15)
  let output = Day14.updateMapEntry (int64 5) input

  Assert.Equal(expected, output)
