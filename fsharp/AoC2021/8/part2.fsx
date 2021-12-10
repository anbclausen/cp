open System.Collections.Generic
open System

let mapping (inp: string[]) =
  let dict = Dictionary<_, _>()
  let one = Array.find (fun (s: string) -> s.Length = 2) inp
  let four = Array.find (fun (s: string) -> s.Length = 4) inp
  let seven = Array.find (fun (s: string) -> s.Length = 3) inp
  let eight = Array.find (fun (s: string) -> s.Length = 7) inp

  let remaining = Array.filter (fun s -> s <> one && s <> four && s <> seven && s <> eight) inp

  let one_set = Set.ofSeq one
  let four_set = Set.ofSeq four
  let seven_set = Set.ofSeq seven 
  let four_seven_set = Set.union four_set seven_set
  let nine = Array.find (fun s -> 
    let num_set = Set.ofSeq s 
    Set.intersect num_set four_seven_set = four_seven_set) remaining

  let remaining' = Array.filter ((<>) nine) remaining

  let zero = Array.find (fun (s: string) -> 
    let num_set = Set.ofSeq s 
    Set.intersect num_set one_set = one_set && s.Length = 6) remaining'
  let remaining'' = Array.filter ((<>) zero) remaining'

  let six = Array.find (fun (s: string) -> s.Length = 6) remaining''
  let remaining''' = Array.filter ((<>) six) remaining''

  let nine_set = Set.ofSeq nine
  let two = Array.find (fun (s: string) -> 
    let num_set = Set.ofSeq s 
    Set.intersect num_set nine_set <> num_set) remaining''' 

  let remaining'''' = Array.filter ((<>) two) remaining''' 

  let three = Array.find (fun (s: string) -> 
    let num_set = Set.ofSeq s 
    Set.intersect num_set one_set = one_set) remaining'''' 
  
  let five = Array.find (fun (s: string) -> 
    let num_set = Set.ofSeq s 
    Set.intersect num_set one_set <> one_set) remaining'''' 

  dict.Add(zero, "0")
  dict.Add(one, "1")
  dict.Add(two, "2")
  dict.Add(three, "3")
  dict.Add(four, "4")
  dict.Add(five, "5")
  dict.Add(six, "6")
  dict.Add(seven, "7")
  dict.Add(eight, "8")
  dict.Add(nine, "9")

  dict

System.IO.File.ReadLines "fsharp/AoC2021/8/input.txt" |> 
Seq.map (fun s -> s.Split " | ") |>
Seq.map (fun sl -> sl.[0], sl.[1]) |>
Seq.map (fun (s, s') -> Array.map Seq.sort (s.Split " "), Array.map Seq.sort (s'.Split " ")) |>
Seq.map (fun (inp, out) -> Seq.map (fun s -> (mapping (Array.map (fun (s: seq<char>) -> String.Concat s) inp)).[s]) (Array.map (fun (s: seq<char>) -> String.Concat s) out)) |>
Seq.map (fun sl -> String.Concat sl) |>
Seq.map int |>
Seq.sum |>
printfn "%i"