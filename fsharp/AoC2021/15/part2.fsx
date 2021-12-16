open System.Collections.Generic
let chr_to_num c = 
  c - 48

let rec wrap t n = 
  if t = 0 then 
    n 
  else 
    let un =
      if n = 9 then 
        1 
      else 
        n + 1
    wrap (t - 1) un
      
let m = 
  System.IO.File.ReadLines "fsharp/AoC2021/15/input.txt" |> 
  Seq.map (Seq.map (int >> chr_to_num)) |>
  Seq.map Array.ofSeq |>
  Array.ofSeq |>
  Array.map (fun arr -> List.fold (fun acc e -> Array.concat [acc; Array.map (wrap e) arr]) arr [1..4]) |>
  (fun arr -> List.fold (fun acc e -> Array.concat [acc; Array.ofList [for a in arr do yield Array.map (wrap e) a]]) arr [1..4])

let oob (x, y) = 
  x < 0 || x >= m.[0].Length || y < 0 || y >= m.Length

let m_indexes = 
  [for i in [0..m.[0].Length - 1] do 
    for j in [0..m.Length - 1] do 
      yield (i, j)]

let maxint = System.Int32.MaxValue

let spt = new Dictionary<_, _>()
for i in m_indexes do 
  spt.Add(i, maxint) 
spt.[(0, 0)] <- 0

let notDone = new HashSet<_>(m_indexes)
let active = new HashSet<_>([0,0])

let neighbors (x, y) = 
  let nb = 
    [x - 1, y;
     x + 1, y;
     x, y - 1;
     x, y + 1]

  [for n in nb do 
    if not (oob n) && notDone.Contains n then 
      yield n]

let mutable count = 1
let dijkstra () = 
  printfn "%i / 250000" count (* This is great for keeping sanity while waiting *)
  count <- count + 1
  let minNode = Seq.minBy (fun t -> spt.[t]) active
  for (nx, ny) in neighbors minNode do 
    let _ = active.Add (nx, ny)
    let tmpDist = spt.[minNode] + m.[ny].[nx]
    if tmpDist < spt.[(nx, ny)] then 
      spt.[(nx, ny)] <- tmpDist
  let _ = notDone.Remove minNode
  let _ = active.Remove minNode
  ()


let w = m.[0].Length
let h = m.Length

while notDone.Contains (w-1, h-1) do 
  dijkstra()

(* Still pretty slow, takes about 1.5 min, but I can live with that :D *)
printfn "%i" (spt.[(w-1, h-1)])