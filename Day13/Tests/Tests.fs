module Tests

open Day13
open Xunit

[<Fact>]
let ``folds along the axis and counts correctly`` () =
  let input =
    """6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0"""

  let singleFold =
    input
    |> pointsFromString
    |> fold (Fold.Horizontal 7)

  printfn $"{singleFold}"
  Assert.Equal(17, List.length singleFold)

//  let doubleFold = singleFold |> fold (Fold.Vertical 5)
//  printfn $"{doubleFold}"
//  Assert.Equal(17, List.length doubleFold)
