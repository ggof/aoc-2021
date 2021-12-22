module Tests

open System
open Xunit
open Lib

[<Fact>]
let ``numberOfPaths - returns correct number of paths`` () =
  let mutable s =
    { name = "start"
      size = Size.Small
      neighbours = [] }

  let mutable e =
    { name = "end"
      size = Size.Small
      neighbours = [] }

  let a =
    { name = "A"
      size = Size.Large
      neighbours = [] }

  let b =
    { name = "b"
      size = Size.Small
      neighbours = [] }

  let c =
    { name = "c"
      size = Size.Small
      neighbours = [] }

  let d =
    { name = "d"
      size = Size.Small
      neighbours = [] }
    
  a.neighbours <- [s; e; c; b]
  b.neighbours <- [s; e; a; d]
  s.neighbours <- [a; b]
  e.neighbours <- [a; b]
  c.neighbours <- [a]
  d.neighbours <- [b]
  
  Assert.Equal(10, numberOfPaths 0 s)
  Assert.Equal(36, numberOfPaths 1 s)
  
[<Fact>]
let ``fromString - parses correctly and calculates amount`` () =
  let input = """dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc"""
  let input2 = """fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW"""
  Assert.Equal(19, fromString 0 input)
  Assert.Equal(226, fromString 0 input2)
  Assert.Equal(103, fromString 1 input)
  Assert.Equal(3509, fromString 1 input2)
  