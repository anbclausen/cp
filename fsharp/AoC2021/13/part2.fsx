let points, folds =
  System.IO.File.ReadLines "fsharp/AoC2021/13/input.txt" |>
  List.ofSeq |>
  (fun lst -> List.splitAt (List.findIndex ((=) "") lst) lst) |>
  (fun (points, folds) -> points, List.tail folds) |>
  (fun (points, folds) -> List.map (fun (s: string) -> s.Split ",") points, List.map (fun (s: string) -> s.Split " ") folds) |>
  (fun (points, folds) -> List.map (Array.map int) points, List.map (fun (lst: string array) -> lst.[2]) folds) |>
  (fun (points, folds) -> List.map (fun (arr: int array) -> arr.[0], arr.[1]) points, List.map (fun (s: string) -> s.Split "=") folds) |>
  (fun (points, folds) -> points, List.map (fun (arr: string array) -> arr.[0], int arr.[1]) folds)

let point_set = Set.ofList points

let fld (points: Set<int * int>) (axis: string, i: int) = 
  match axis with 
  | "x" -> 
    let safe = Set.filter (fun (x, _) -> x < i) points
    let unsafe = Set.filter (fun (x, _) -> x > i) points
    let flipped = Set.map (fun (x, y) -> (i - (x - i), y)) unsafe
    Set.union safe flipped
  | "y" ->
    let safe = Set.filter (fun (_, y) -> y < i) points
    let unsafe = Set.filter (fun (_, y) -> y > i) points
    let flipped = Set.map (fun (x, y) -> (x, i - (y - i))) unsafe
    Set.union safe flipped
  | _ -> Set.empty (* Impossible *)

let res = List.fold fld point_set folds (* no pun intended *)

let drawing = Array.ofList [for _ in [0..5] do yield Array.ofList [for _ in [0..38] do yield "."]]
Seq.iter (fun (x, y) -> drawing.[y].[x] <- "#") res

for i in [0..5] do 
  for j in [0..38] do 
    printf "%s" drawing.[i].[j]
  printfn ""