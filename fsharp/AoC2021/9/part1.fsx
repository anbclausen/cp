let chr_to_num c = 
  c - 48

let m = 
  System.IO.File.ReadLines "fsharp/AoC2021/9/input.txt" |> 
  Seq.map (Seq.map (int >> chr_to_num)) |>
  Seq.map List.ofSeq |>
  List.ofSeq

let oob (x, y) = 
  x < 0 || x >= m.[0].Length || y < 0 || y >= m.Length

let low_point (x, y) = 
  let neighbors = 
    [(x - 1, y);
     (x + 1, y);
     (x, y - 1);
     (x, y + 1)]
  List.fold (fun acc (nx, ny) -> (oob (nx, ny) || m.[ny].[nx] > m.[y].[x]) && acc) true neighbors 

let m_indexes = 
  [for i in [0..m.[0].Length - 1] do 
    for j in [0..m.Length - 1] do 
      yield (i, j)]

let low_points = List.filter low_point m_indexes

low_points |>
List.map (fun (x, y) -> m.[y].[x] + 1) |>
List.sum |>
printfn "%i"