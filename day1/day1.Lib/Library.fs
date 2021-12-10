namespace day1

module Lib =
  let toInt [| a; b |] = if a >= b then 0 else 1

  let calculateTotal =
    Seq.windowed 2 >> Seq.map toInt >> Seq.sum

  let calculateTotalWindowed: seq<int> -> int =
    Seq.windowed 3
    >> (Seq.map Seq.sum<int>)
    >> calculateTotal
