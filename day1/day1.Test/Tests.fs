namespace day1

module Tests =
  open Xunit
  open day1.Lib

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

  [<Fact>]
  let ``calculates the number of times depth has increased`` () =
    Assert.Equal(7, calculateTotal numbers)

  [<Fact>]
  let ``calculates the number of times depth has increased, windowed by 3`` () =
    Assert.Equal(5, calculateTotalWindowed numbers)
