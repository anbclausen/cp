open System

let w = Console.ReadLine() |> int
let n = Console.ReadLine() |> int
let mutable area = 0
for _ in [1..n] do 
    area <- area + (Console.ReadLine().Split " " |> Array.map int |> fun l -> l.[0] * l.[1])

printfn "%i" (area / w)