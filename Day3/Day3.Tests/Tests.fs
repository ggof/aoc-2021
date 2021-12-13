module Tests

open System
open System.Numerics
open Day3
open Xunit

type Test () =
  let input =
    [ "00100"
      "11110"
      "10110"
      "10111"
      "10101"
      "01111"
      "00111"
      "11100"
      "10000"
      "11001"
      "00010"
      "01010" ]

  [<Fact>]
  let ``finds the most common bit for each position in the sequence`` () =
    Assert.Equal("10110", Lib.findGamma input)

  [<Fact>]
  let ``given gamma, finds epsilon`` () =
    let gamma = "10110"

    Assert.Equal("01001", Lib.findEpsilon gamma)

  [<Fact>]
  let ``given gamma and epsilon, find power rate`` () =
    let gamma = "10110"
    let epsilon = "01001"

    Assert.Equal(198, Lib.calculateRating gamma epsilon)

  [<Fact>]
  let ``finds O2Rating`` () =
    Assert.Equal("10111", Lib.findO2Rating input)
    
  [<Fact>]
  let ``finds CO2Rating`` () =
    Assert.Equal("01010", Lib.findCO2Rating input)
