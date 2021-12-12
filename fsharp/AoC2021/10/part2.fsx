System.IO.File.ReadLines "fsharp/AoC2021/10/input.txt" |> 
Seq.map (
  Seq.fold (fun (opened, illegal) c -> 
    match illegal with 
    | Some chr -> ([], Some chr)
    | None -> 
      match c with 
      | '(' -> ('(' :: opened, None) 
      | '[' -> ('[' :: opened, None) 
      | '{' -> ('{' :: opened, None)
      | '<' -> ('<' :: opened, None)
      | ')' -> 
        (match opened with 
        | '(' :: tl -> (tl, None)
        | _ -> ([], Some ')'))
      | ']' ->
        (match opened with 
        | '[' :: tl -> (tl, None)
        | _ -> ([], Some ']'))
      | '}' -> 
        (match opened with 
        | '{' :: tl -> (tl, None)
        | _ -> ([], Some '}'))
      | '>' -> 
        (match opened with 
        | '<' :: tl -> (tl, None)
        | _ -> ([], Some '>'))
      | _ -> ([], None) (* Impossible case *)) ([], None)) |>
Seq.filter 
  (fun (_, illegal) -> 
    match illegal with 
    | Some _ -> false 
    | _ -> true) |>
Seq.map fst |>
Seq.map
  (Seq.fold (fun acc e -> 
    acc * 5I + 
      match e with 
      | '(' -> 1I 
      | '[' -> 2I 
      | '{' -> 3I 
      | '<' -> 4I
      | _ -> 0I) 0I) |>
List.ofSeq |>
List.sort |>
(fun lst -> lst.[lst.Length / 2]) |>
printfn "%A"