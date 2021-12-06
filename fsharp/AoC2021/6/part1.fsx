let mutable fish = 
  System.IO.File.ReadLines "fsharp/AoC2021/6/input.txt" |> 
  Seq.head |>
  (fun s -> s.Split ",") |>
  Array.ofSeq |>
  Array.map int

let mutable i = 0
while i < 80 do 
  let mutable children: int[] = [||]
  for j in [0..fish.Length - 1] do 
    if fish.[j] > 0 then 
      fish.[j] <- fish.[j] - 1
    else 
      fish.[j] <- 6
      children <- Array.append children [|8|]
  fish <- Array.append fish children
  i <- i + 1

printfn "%i" fish.Length