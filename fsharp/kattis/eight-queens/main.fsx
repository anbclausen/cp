open System

let map = List.toArray [for _ in [0..7] do yield (Seq.toArray (Console.ReadLine()))]

let oob i = 
  if i < 0 || i > 7 then 
    true
  else 
    false

let queen (x, y) =
  if oob x || oob y then 
    false
  else 
    map.[y].[x] = '*'

let rec attacking_on_diag (x, y) offset =
  let p1 = (x - offset , y + offset)
  let p2 = (x + offset , y + offset)
  let oob_t (x, y) = oob x || oob y
  if oob_t p1 && oob_t p2 then
    false
  else 
    queen p1 ||
    queen p2 ||
    attacking_on_diag (x, y) (offset + 1)

let attacking (x, y) =
  let invalidNumOfQueens = Array.filter ((=) '*') >> (fun l -> l.Length) >> (<>) 1
  invalidNumOfQueens map.[y] ||
  invalidNumOfQueens (List.toArray [for i in [0..7] do yield map.[i].[x]]) ||
  attacking_on_diag (x, y) 1


let invalid = List.fold (||) false [for i in [0..7] do
                                      for j in [0..7] do 
                                        if map.[i].[j] = '*' then 
                                          yield attacking (j, i)
                                        else 
                                          yield false]

let numOfQueens = map |> Array.reduce Array.append |> Array.filter (fun c -> c = '*') |> Array.length
                     
if invalid || numOfQueens <> 8 then 
  printfn "invalid"
else
  printfn "valid"