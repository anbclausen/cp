open System

Console.ReadLine() |>
float |>
(fun f-> printfn "%f\n%f" (100.0 / f) (100.0 / (100.0 - f))) 