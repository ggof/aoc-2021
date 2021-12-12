module Tests

open System.IO
open Day2


open Xunit

[<Fact>]
let ``should end at 15 horizontal, 10 vertical`` () =
  let input =
    [ "forward 5"
      "down 5"
      "forward 8"
      "up 3"
      "down 8"
      "forward 2" ]
  let pos = Lib.navigate input

  Assert.Equal(15, pos.x)
  Assert.Equal(10, pos.y)

[<Fact>]
let ``with aim, should end at x=15, y=60`` () =
  let input =
    [ "forward 5"
      "down 5"
      "forward 8"
      "up 3"
      "down 8"
      "forward 2" ]

  let pos = Lib.navigateWithAim input
  
  Assert.Equal(15, pos.x)
  Assert.Equal(60, pos.y)