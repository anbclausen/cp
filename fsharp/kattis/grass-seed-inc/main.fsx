open System

let cost = float (Console.ReadLine())
let _ = Console.ReadLine()

let res = (fun _ -> Console.ReadLine()) |>
          Seq.initInfinite |>
          Seq.takeWhile ((<>) null) |>
          Seq.map (fun x -> 
                    let words = x.Split ' '
                    cost * float words.[0] * float words.[1]) |>
          Seq.sum

printfn "%f" res