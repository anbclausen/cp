open System

let n = Console.ReadLine()
if n = "0" then 
    printfn "0" 
else
    Console.ReadLine() |>
    (fun s -> s.Split " ") |>
    Seq.map int |>
    Seq.filter ((>) 0)  |>
    Seq.sum |>
    (*) -1 |>
    printfn "%i"