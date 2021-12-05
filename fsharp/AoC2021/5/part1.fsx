open System.Collections.Generic
let dict = new Dictionary<int * int, int>()

let add e = 
  if dict.ContainsKey e then 
    dict.[e] <- dict.[e] + 1
  else 
    dict.Add(e, 1)

let points (sx, sy) (ex, ey) =
  if sx = ex then 
    [for i in [min sy ey..max sy ey] do yield (sx, i)]
  elif sy = ey then 
    [for i in [min sx ex..max sx ex] do yield (i, sy)]
  else 
    []

System.IO.File.ReadLines "fsharp/AoC2021/5/input.txt" |>
Seq.map (fun s -> Seq.concat (Seq.map (fun (s' : string) -> s'.Split ',') (s.Split " -> "))) |>
Seq.map (fun sl -> Seq.map int sl) |>
Seq.map List.ofSeq |>
Seq.map (fun lst -> points (lst.[0], lst.[1]) (lst.[2], lst.[3])) |>
Seq.iter (fun lst -> List.iter add lst)

printfn "%i" (List.sum [for entry in dict do yield if entry.Value > 1 then 1 else 0])