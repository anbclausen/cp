open System 

Console.ReadLine().Split "()" |>
(fun l -> l.[0] = l.[1]) |>
(fun b -> if b then "correct" else "fix") |>
printfn "%s"