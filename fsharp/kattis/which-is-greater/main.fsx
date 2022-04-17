open System

Console.ReadLine() |>
(fun s -> s.Split " ") |>
Array.map int |>
(fun l -> l.[0] > l.[1]) |>
(fun b -> if b then 1 else 0) |>
printfn "%i"