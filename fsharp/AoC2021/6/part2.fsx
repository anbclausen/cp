open System.Collections.Generic

let fish = 
  System.IO.File.ReadLines "fsharp/AoC2021/6/input.txt" |> 
  Seq.head |>
  (fun s -> s.Split ",") |>
  List.ofSeq |>
  List.map int |>
  List.map bigint

let dict = Dictionary<_, _>()

let rec contribution (days: bigint) (n: bigint) : bigint =
  let exist, value = dict.TryGetValue n
  match exist with 
  | true -> value 
  | _ -> 
    let value = 1I + if n <= days then 
                      List.sum [for i in [n .. (7I) .. days] do yield contribution days (i + (9I))]
                    else 
                      0I
    dict.Add(n, value)
    value

let afterDays n =
  List.sum (List.map (contribution n) fish)

printfn "%A" (afterDays (255I))