open System

(fun _ -> Console.ReadLine()) |>
Seq.initInfinite |>
Seq.takeWhile ((<>) null) |>
Seq.tail |>
Seq.iter (fun s -> 
  let dim = s.Length |> float |> sqrt |> int
  printfn "%s" ([for i in [dim - 1 .. -1 .. 0] do for j in [0 .. dim - 1] do yield s.[dim * j + i]] |> Array.ofSeq |> System.String.Concat))