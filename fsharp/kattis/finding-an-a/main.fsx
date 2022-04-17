open System 

Console.ReadLine() |>
Seq.skipWhile ((<>) 'a') |>
String.Concat |>
printfn "%s"