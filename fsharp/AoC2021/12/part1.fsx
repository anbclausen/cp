open System.Collections.Generic

let connections = new Dictionary<string, string list>()

let connect n1 n2 = 
  connections.[n1] <- n2 :: if connections.ContainsKey n1 then connections.[n1] else []
  connections.[n2] <- n1 :: if connections.ContainsKey n2 then connections.[n2] else []

System.IO.File.ReadLines "fsharp/AoC2021/12/input.txt" |> 
Seq.map (fun s -> s.Split "-") |>
Seq.iter (fun arr -> connect (arr.[0]) (arr.[1]))

let mutable paths = 0

let rec dfs (node: string) (path: string list) = 
  if node = node.ToUpper() || not (List.contains node path) then 
    if node = "end" then 
      paths <- paths + 1
    else
      for n in connections.[node] do 
        dfs n (node :: path)

dfs "start" []

printfn "%i" paths