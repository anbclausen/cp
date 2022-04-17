open System

let vowels = Set.ofList ['a'; 'e'; 'i'; 'o'; 'u'; 'A'; 'E'; 'I'; 'O'; 'U']

Console.ReadLine() |>
Seq.filter (fun c -> vowels.Contains c) |>
Seq.length |>
printfn "%i"