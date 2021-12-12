open System.Collections

let chr_to_num c = 
  c - 48

let m = 
  System.IO.File.ReadLines "fsharp/AoC2021/11/input.txt" |> 
  Seq.map (Seq.map (int >> chr_to_num)) |>
  Seq.map Array.ofSeq |>
  Array.ofSeq

let oob (x, y) = 
  x < 0 || x >= m.[0].Length || y < 0 || y >= m.Length

let m_indexes = 
  [for i in [0..m.[0].Length - 1] do 
    for j in [0..m.Length - 1] do 
      yield (i, j)]

(* some sort of dfs *)
let rec flash (q: Queue) (x, y) = 
  if m.[y].[x] > 9 && not (q.Contains (x, y)) then 
    q.Enqueue((x, y))
    let neighbors = 
      [(x - 1, y);
      (x + 1, y);
      (x, y - 1);
      (x, y + 1);
      (x - 1, y - 1);
      (x + 1, y - 1);
      (x - 1, y + 1);
      (x + 1, y + 1);]
    for n in neighbors do 
      if not (oob n) then 
        let (nx, ny) = n 
        m.[ny].[nx] <- m.[ny].[nx] + 1
        flash q n

let step () =
  m_indexes |> List.iter (fun (x, y) -> m.[y].[x] <- m.[y].[x] + 1)
  let flashed = new Queue()
  m_indexes |> List.iter (flash flashed)
  m_indexes |> List.iter (fun (x, y) -> if m.[y].[x] > 9 then m.[y].[x] <- 0)
  flashed.Count

[for i in [1..1000] do yield (i, step ())] |>
List.filter (fun (_, v) -> v = m.Length * m.[0].Length) |>
List.map fst |>
List.head |>
printfn "%i"