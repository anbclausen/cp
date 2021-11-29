open System
open System.Collections.Generic

exception NotImplemented

let mutable name_env = Dictionary<int, string option>()
let mutable val_env = Dictionary<string, int option>()


let add s i =
  if val_env.ContainsKey s then 
    let value = Option.get val_env.[s]
    let _ = val_env.Remove(s)
    let _ = name_env.Remove(value)
    ()
  
  val_env.Add(s, Some i)
  name_env.Add(i, Some s)

let look_int k =
  snd (name_env.TryGetValue(k))

let look_str k =
  snd (val_env.TryGetValue(k))

let clear () =
  name_env.Clear()
  val_env.Clear()

let emulate (s: string) = 
  let tokens = s.Split(' ')
  match tokens.[0] with
  | "def" -> add (tokens.[1]) (int tokens.[2])
  | "calc" -> 
    let expr_tokens = tokens.[1..tokens.Length - 2]
    let nums = List.map (fun e -> look_str e) [for i in [0..2..(expr_tokens.Length - 1)] do yield expr_tokens.[i]] 
    let ops = [for i in [1..2..(expr_tokens.Length - 1)] do yield expr_tokens.[i]]
    let op_num = List.zip ops nums.[1..]
    let opt_res = List.fold (fun acc (op, num) -> 
      match acc with 
      | None -> None 
      | Some i -> 
        match num with 
        | None -> None
        | Some n -> 
          match op with 
          | "+" -> Some(i + n)
          | "-" -> Some(i - n)
          | _ -> raise NotImplemented) nums.[0] op_num
    let res = 
      match opt_res with 
      | None -> "unknown"
      | Some i -> 
        match look_int i with
        | None -> "unknown"
        | Some s -> s
    printfn "%s" (s.[5..] + " " + res)
  | "clear" -> clear ()
  | _ -> raise NotImplemented

(fun _ -> Console.ReadLine()) |>
Seq.initInfinite |>
Seq.takeWhile ((<>) null) |>
Seq.iter emulate