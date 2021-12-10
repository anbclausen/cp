System.IO.File.ReadLines "fsharp/AoC2021/8/input.txt" |> 
Seq.map (fun s -> s.Split " | ") |>
Seq.map (fun sl -> sl.[1]) |>
Seq.map (fun s -> s.Split " ") |>
Seq.concat |>
Seq.filter (fun s -> s.Length = 2 || s.Length = 3 || s.Length = 4 || s.Length = 7) |>
Seq.length |>
printfn "%i"