let inp = Seq.toList (System.IO.File.ReadLines "fsharp/AoC2021/3/input.txt") |>
          List.map (fun s -> List.map (fun c -> int c) (Seq.toList s))

let mutable ones = Array.init (inp.[0].Length) (fun _ -> 0)
let mutable zeroes = Array.init (inp.[0].Length) (fun _ -> 0)
let mutable gamma = Array.init (inp.[0].Length) (fun _ -> 0)
let mutable epsilon = Array.init (inp.[0].Length) (fun _ -> 0)

for line in inp do 
  List.iteri (fun i e ->
             if e = 48 then (* char '0' = 48 *)
              zeroes.[i] <- zeroes.[i] + 1
             else 
              ones.[i] <- ones.[i] + 1) line

for i in 0..gamma.Length - 1 do 
  if zeroes.[i] > ones.[i] then
    gamma.[i] <- 0
    epsilon.[i] <- 1
  else 
    gamma.[i] <- 1
    epsilon.[i] <- 0

let gamma_n, _ = Array.fold (fun (acc, pow) e -> (acc + e * pow, pow * 2)) (0, 1) (Array.rev gamma)
let epsilon_n, _ = Array.fold (fun (acc, pow) e -> (acc + e * pow, pow * 2)) (0, 1) (Array.rev epsilon)

printfn "%i" (gamma_n * epsilon_n)