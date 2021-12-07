open System

(fun _ -> Console.ReadLine()) |>
Seq.initInfinite |>
Seq.takeWhile ((<>) null) |>
Seq.tail |>
Seq.indexed |>
Seq.filter (fun (i, _) -> i % 2 = 1) |>
Seq.map (fun (_, s) -> 
  let nums = Seq.map int (s.Split " ")
  let mi = Seq.min nums 
  let ma = Seq.max nums
  2 * (ma - mi)) |>
Seq.iter (printfn "%i")