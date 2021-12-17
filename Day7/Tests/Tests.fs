module Tests

open System
open Xunit

[<Fact>]
let ``Lib.incrementalFuel calculates the correct amount`` () =
  let assertEqual (pos, cur, expected) =
    Assert.Equal(expected, Lib.incrementalFuel pos cur)

  [ (16, 5, 66)
    (1, 5, 10)
    (2, 5, 6)
    (0, 5, 15)
    (4, 5, 1)
    (2, 5, 6)
    (7, 5, 3)
    (1, 5, 10)
    (2, 5, 6)
    (14, 5, 45) ]
  |> List.map assertEqual

[<Fact>]
let ``Lib.toFuelConsumedTuple returns a tuple of position, fuelConsumed`` () =
  let input =
    "16,1,2,0,4,2,7,1,2,14".Split(",")
    |> Array.map int

  Assert.Equal((2, 37), Lib.toFuelConsumedTuple (-) input 2)


[<Fact>]
let ``Lib.lowestFuelSubsctract returns the lowest position and fuel consumed`` () =
  let input = "16,1,2,0,4,2,7,1,2,14"
  let expected = (2, 37)
  let result = Lib.lowestFuelSubstract input |> Async.AwaitTask |> Async.RunSynchronously

  Assert.Equal(expected, result)

[<Fact>]
let ``Lib.lowestFuelIncremental returns the lowest position and fuel consumed`` () =
  let input = "16,1,2,0,4,2,7,1,2,14"
  let expected = (5, 168)
  let result = Lib.lowestFuelIncremental input |> Async.AwaitTask |> Async.RunSynchronously

  Assert.Equal(expected, result)