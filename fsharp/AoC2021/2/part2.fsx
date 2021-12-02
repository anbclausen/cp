open System

let mutable depth = 0
let mutable pos = 0
let mutable aim = 0

System.IO.File.ReadLines "fsharp/AoC2021/2/input.txt" |>
Seq.map (fun x -> 
          let words = x.Split ' '
          (words.[0], int words.[1])) |>
Seq.iter (fun (typ, v) -> 
          match typ with 
          | "forward" -> pos <- pos + v
                         depth <- depth + aim * v
          | "down"    -> aim <- aim + v
          | "up"      -> aim <- aim - v
          | _         -> ()) (* impossible case, keeping compiler happy *)

printfn "%i" (depth * pos)