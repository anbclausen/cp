open System.Collections.Generic
let init, rules =
  System.IO.File.ReadLines "fsharp/AoC2021/14/input.txt" |>
  List.ofSeq |>
  (fun lst -> List.splitAt (List.findIndex ((=) "") lst) lst) |>
  (fun (init, rules) -> init, List.tail rules) |>
  (fun (init, rules) -> init.[0], List.map (fun (s: string) -> s.Split " -> ") rules) |>
  (fun (init, rules) -> init, List.map (fun (arr: string array) -> arr.[0], arr.[1]) rules)

let letters_seen = new Dictionary<char, bigint>()
for letter in ['A'..'Z'] do 
  letters_seen.Add(letter, 0I)

let mutable combinations = new Dictionary<string, bigint>()
for l1 in ['A'..'Z'] do 
  for l2 in ['A'..'Z'] do
    combinations.Add(string l1 + string l2, 0I)

Seq.iter (fun l -> letters_seen.[l] <- letters_seen.[l] + 1I) init
List.iter (fun i -> combinations.[init.[i..i+1]] <- combinations.[init.[i..i+1]] + 1I) [0..init.Length-2]


let apply () = 
  let tmp = new Dictionary<string, bigint>(combinations)
  for (f, _) in rules do 
    if tmp.[f] > 0I then 
      combinations.[f] <- 0I
  for (f, t) in rules do 
    if tmp.[f] > 0I then 
      letters_seen.[t.[0]] <- letters_seen.[t.[0]] + tmp.[f]
      combinations.[string f.[0] + string t.[0]] <- combinations.[string f.[0] + string t.[0]] + tmp.[f]
      combinations.[string t.[0] + string f.[1]] <- combinations.[string t.[0] + string f.[1]] + tmp.[f]
        

for _ in [1..40] do 
  apply()

let counts = List.ofSeq letters_seen
let stripped_counts = List.filter (fun (p: KeyValuePair<char, bigint>) -> p.Value > 0I) counts
let mi = List.minBy (fun (p: KeyValuePair<char, bigint>) -> p.Value) stripped_counts
let ma = List.maxBy (fun (p: KeyValuePair<char, bigint>) -> p.Value) stripped_counts

printfn "%A" (ma.Value - mi.Value)