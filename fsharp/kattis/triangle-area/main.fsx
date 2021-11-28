open System
let res = Console.ReadLine().Split(' ')   |>
          Seq.map (fun s -> float s)      |>
          Seq.fold (fun acc e -> acc * e) 0.5

printfn "%f" res