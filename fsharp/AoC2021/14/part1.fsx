open System.Collections.Generic
let init, rule_list =
  System.IO.File.ReadLines "fsharp/AoC2021/14/input.txt" |>
  List.ofSeq |>
  (fun lst -> List.splitAt (List.findIndex ((=) "") lst) lst) |>
  (fun (init, rules) -> init, List.tail rules) |>
  (fun (init, rules) -> init.[0], List.map (fun (s: string) -> s.Split " -> ") rules) |>
  (fun (init, rules) -> init, List.map (fun (arr: string array) -> arr.[0], arr.[1]) rules)

let rules = new Dictionary<string, string>()
List.iter (fun (k, v) -> rules.[k] <- v) rule_list

let apply (str: string) = 
  let first = string (Seq.head str)
  let rest = 
    [for i in [0..str.Length - 2] do 
      let sub = str.[i..i+1]
      if rules.ContainsKey sub then 
        rules.[sub] + string str.[i+1]
      else 
        string str.[i+1]]
  let res_list = first :: rest
  System.String.Concat res_list

let res = Seq.fold (fun acc _ -> apply acc) init [1..10]

let letters = Set.ofSeq res 
let counts = [for l in letters do yield (l, Seq.filter ((=) l) res |> Seq.length)]
let _, mi = List.minBy (fun (_, n) -> n) counts
let _, ma = List.maxBy (fun (_, n) -> n) counts

printfn "%i" (ma - mi)