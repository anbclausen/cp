open System

(fun _ -> Console.ReadLine()) |>
Seq.initInfinite |>
Seq.takeWhile ((<>) null) |>
Seq.tail |>
Seq.map (fun s -> Seq.map float (s.Split " ")) |>
Seq.map List.ofSeq |>
Seq.map (fun (b :: p :: _) -> 
  let a = 60.0 / p
  let bpm = 60.0 * b / p
  sprintf "%f %f %f" (bpm - a) bpm (bpm + a)) |>
Seq.iter (printfn "%s")

