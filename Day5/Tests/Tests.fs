module Tests

open Expecto

[<Tests>]
let ``Lib.lineToPoints`` () =
  testList
    "Lib"
    [ testList
        "onlyPoints"
        [ test "given straight input, returns true" {
            let input = ((9, 4), (3, 4))
            Expect.isTrue (Lib.onlyStraight input) "lists do not match"
          }
          test "given diagonal input, returns false" {
            let input = ((1, 2), (2, 1))
            Expect.isFalse (Lib.onlyStraight input) "lists do not match"
          } ]

      testList
        "lineToPoints"
        [ test "given single line of input, creates a tuple of points" {
            let input = "9,4 -> 3,4"
            Expect.equal (Lib.lineToPoints input) ((9, 4), (3, 4)) "tuples did not match"
          } ]

      testList
        "totalOverlapsStraight"
        [ test "given input, calculates the number of points where more than 2 points overlap, only straight lines" {
            let input =
              [ "0,9 -> 5,9"
                "8,0 -> 0,8"
                "9,4 -> 3,4"
                "2,2 -> 2,1"
                "7,0 -> 7,4"
                "6,4 -> 2,0"
                "0,9 -> 2,9"
                "3,4 -> 1,4"
                "0,0 -> 8,8"
                "5,5 -> 8,2" ]

            Expect.equal (Lib.totalOverlapsStraight input) 5 "output was not 5"
          } ]

      testList
        "totalOverlaps"
        [ test "given input, calculates the number of points where more than 2 points overlap" {
            let input =
              [ "0,9 -> 5,9"
                "8,0 -> 0,8"
                "9,4 -> 3,4"
                "2,2 -> 2,1"
                "7,0 -> 7,4"
                "6,4 -> 2,0"
                "0,9 -> 2,9"
                "3,4 -> 1,4"
                "0,0 -> 8,8"
                "5,5 -> 8,2" ]

            Expect.equal (Lib.totalOverlaps input) 12 "output was not 12"
          } ] ]
