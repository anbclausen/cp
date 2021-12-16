open System.Collections.Generic
let chr_to_num c = 
  c - 48

let m = 
  System.IO.File.ReadLines "fsharp/AoC2021/15/input.txt" |> 
  Seq.map (Seq.map (int >> chr_to_num)) |>
  Seq.map Array.ofSeq |>
  Array.ofSeq

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

let mutable notDone = Set.ofList m_indexes

let neighbors (x, y) = 
  let nb = 
    [x - 1, y;
     x + 1, y;
     x, y - 1;
     x, y + 1]

  [for n in nb do 
    if not (oob n) && Set.contains n notDone then 
      yield n]


let dijkstra () = 
  let notDoneList = List.ofSeq notDone
  let minNode = List.minBy (fun t -> spt.[t]) notDoneList
  for (nx, ny) in neighbors minNode do 
    let tmpDist = spt.[minNode] + m.[ny].[nx]
    if tmpDist < spt.[(nx, ny)] then 
      spt.[(nx, ny)] <- tmpDist
  notDone <- Set.remove minNode notDone

while not notDone.IsEmpty do 
  dijkstra()

let w = m.[0].Length
let h = m.Length

printfn "%i" (spt.[(w-1, h-1)])