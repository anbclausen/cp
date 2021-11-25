open System 

let inp = Console.ReadLine()
let ans = Array.toList (inp.Split ';') |>
  List.map (fun (s : string) -> if Seq.contains '-' s then 
                                  let [hd; tl] = Array.toList (s.Split '-')
                                  (int tl) - (int hd) + 1
                                else 1) |>
  List.sum

printfn "%i" ans