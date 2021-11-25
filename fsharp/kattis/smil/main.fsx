open System
let inp = Console.ReadLine()
let rec solve s i = 
  match s with 
  | [] -> []
  | ':' :: ')' :: rs 
  | ';' :: ')' :: rs 
    -> i :: solve rs (i + 2)
  | ':' :: '-' :: ')' :: rs 
  | ';' :: '-' :: ')' :: rs 
    -> i :: solve rs (i + 3)
  | _ :: rs -> solve rs (i + 1)

for i in solve (Seq.toList inp) 0 do 
  printfn "%i" i