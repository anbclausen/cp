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
Seq.map (fun (_, illegal) -> 
  match illegal with 
  | Some c ->
    (match c with 
    | ')' -> 3
    | ']' -> 57 
    | '}' -> 1197
    | '>' -> 25137
    | _ -> 0) (* Impossible case *)
  | None -> 0) |>
Seq.sum |>
printfn "%i"