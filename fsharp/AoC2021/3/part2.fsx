let inline charToInt c = int c - int '0'
let inp = Seq.toList (System.IO.File.ReadLines "fsharp/AoC2021/3/input.txt") |>
          List.map (fun s -> List.map charToInt (Seq.toList s))

let most_common_bit i (candidates: list<list<int>>) = 
  let mutable zeroes = 0
  let mutable ones = 0
  for candidate in candidates do 
      if candidate.[i] = 0 then
        zeroes <- zeroes + 1
      else 
        ones <- ones + 1
  if zeroes > ones then 0 else 1

let least_common_bit i candidates =
  if most_common_bit i candidates = 0 then 1 else 0

let rec find_ox (lst: list<list<int>>) current_bit = 
  if lst.Length = 1 then 
    List.head lst
  else 
    find_ox (List.filter (fun e -> e.[current_bit] = most_common_bit current_bit lst) lst) (current_bit + 1)
    
let rec find_co2 (lst: list<list<int>>) current_bit = 
  if lst.Length = 1 then 
    List.head lst
  else 
    find_co2 (List.filter (fun e -> e.[current_bit] = least_common_bit current_bit lst) lst) (current_bit + 1)

let ox_n, _ = List.fold (fun (acc, pow) e -> (acc + e * pow, pow * 2)) (0, 1) (List.rev (find_ox inp 0))
let co2_n, _ = List.fold (fun (acc, pow) e -> (acc + e * pow, pow * 2)) (0, 1) (List.rev (find_co2 inp 0))

printfn "%i" (ox_n * co2_n)