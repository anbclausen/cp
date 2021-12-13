open System.Collections.Generic

let connections = new Dictionary<string, string list>()

let connect n1 n2 = 
  connections.[n1] <- n2 :: if connections.ContainsKey n1 then connections.[n1] else []
  connections.[n2] <- n1 :: if connections.ContainsKey n2 then connections.[n2] else []

System.IO.File.ReadLines "fsharp/AoC2021/12/input.txt" |> 
Seq.map (fun s -> s.Split "-") |>
Seq.iter (fun arr -> connect (arr.[0]) (arr.[1]))

let mutable paths = Set.empty

let rec dfs (node: string) (path: string list) (special: string) = 
  if node = node.ToUpper() || not (List.contains node path) || (node = special && (List.filter ((=) special) path).Length < 2) then 
    if node = "end" then 
      let final = "end" :: path
      paths <- paths.Add final
    else
      for n in connections.[node] do 
        dfs n (node :: path) special

let smallCaves = List.filter (fun (s: string) -> s = s.ToLower() && s <> "start" && s <> "end") [for k in connections.Keys do yield k]
for cave in smallCaves do 
  dfs "start" [] cave

printfn "%i" paths.Count