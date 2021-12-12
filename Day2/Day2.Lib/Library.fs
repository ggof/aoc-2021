namespace Day2

module Lib =
  open System

  type Position = { x: int; y: int; aim: int }

  type Command =
    | Forward of int
    | Up of int
    | Down of int

  let private toCommand (input: String) =
    let parts = input.Split(" ")
    let quantity = int (Array.last parts)

    match Array.head parts with
    | "forward" -> Forward(quantity)
    | "up" -> Up(quantity)
    | "down" -> Down(quantity)
    | _ -> Forward(0) // dont move

  let private move cmd (current: Position) : Position =
    match cmd with
    | Up qt -> { current with y = current.y - qt }
    | Down qt -> { current with y = current.y + qt }
    | Forward qt -> { current with x = current.x + qt }

  let private moveWithAim cmd (current: Position) : Position =
    match cmd with
    | Up qt -> { current with aim = current.aim - qt}
    | Down qt -> { current with aim =current.aim + qt}
    | Forward qt ->
      { current with
          x = current.x + qt
          y = current.y + (qt * current.aim) }

  let parseCommandAndMove = toCommand >> move
  let parseCommandAndMoveWithAim = toCommand >> moveWithAim

  let rec private loop inputs action =
      match inputs with
      | [] -> { x = 0; y = 0; aim = 0 }
      | hd :: tl -> action hd (loop tl action)
      
  let navigate inputs =
    loop (List.rev inputs) parseCommandAndMove

  let navigateWithAim inputs =
    loop (List.rev inputs) parseCommandAndMoveWithAim
  
  let multiply pos = pos.x * pos.y