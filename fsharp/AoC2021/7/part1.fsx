let pos =
  System.IO.File.ReadLines "fsharp/AoC2021/7/input.txt" |> 
  Seq.head |>
  (fun s -> s.Split ",") |>
  List.ofSeq |>
  List.map int

let minPos = List.min pos 
let maxPos = List.max pos

[for i in[minPos .. maxPos] do 
  yield List.map (fun p -> abs (p - i)) pos] |>
List.map List.sum |>
List.min |>
printfn "%i"