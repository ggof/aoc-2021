module Tests

open Expecto
open Lib

[<Tests>]
let tests =
  testList
    "Fishes"
    [ testList
        "ofString"
        [ test "outputs list of numbers" {
            let input = "3,4,3,1,2"
            Expect.equal (Fishes.ofString input) [ 3; 4; 3; 1; 2 ] "lists are not the same"
          } ]

      testList
        "nextDay"
        [ test "rotates list" {
            let input = [ 0L; 1L; 2L; 3L; 4L; 5L; 6L; 7L; 8L ]
            Expect.equal (Fishes.nextDay input) [ 1L; 2L; 3L; 4L; 5L; 6L; 7L; 8L; 0L ] "did not rotate correctly"
          }

          test "adds first to sixth" {
            let input = [ 1L; 2L; 3L; 4L; 5L; 6L; 7L; 8L; 0L ]
            Expect.equal (Fishes.nextDay input) [ 2L; 3L; 4L; 5L; 6L; 7L; 9L; 0L; 1L ] "did not rotate correctly"
          } ]

      testList
        "afterDays"
        [ test "correctly rotates n times" {
            let n = 2
            let input = [ 0L; 1L; 2L; 3L; 4L; 5L; 6L; 7L; 8L ]
            Expect.equal (Fishes.afterDays n input) [ 2L; 3L; 4L; 5L; 6L; 7L; 9L; 0L; 1L ] "did not rotate correctly"
          } ]

      testList
        "totalAfterDays"
        [ test "finds the correct amount after 80 days" {
            let input = "3,4,3,1,2"
            let expected = 5934L

            Expect.equal (Fishes.totalAfterDays 80 input) expected "did not calculate correctly"
          }

          test "finds the correct amount after 256 days" {
            let input = "3,4,3,1,2"
            let expected = 26984457539L

            Expect.equal (Fishes.totalAfterDays 256 input) expected "did not calculate correctly"
          } ] ]
