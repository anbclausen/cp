open System

(fun _ -> Console.ReadLine()) |>
Seq.initInfinite |>
Seq.takeWhile ((<>) null) |>
Seq.map (fun s -> s.Split(' ')) |>
Seq.map (fun sl -> (int sl.[0], int sl.[1])) |>
Seq.map (fun (a, b) ->  if b = 0 then 
                          "" 
                        else
                          string (a / b) + " " + string (a % b) + " / " + string b) |>
Seq.iter (fun s -> if s <> "" then printfn "%s" s)