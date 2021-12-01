let inp = Seq.toList (System.IO.File.ReadLines("fsharp/AoC2021/1/input1.txt")) 
let nums = List.map int inp

let res = [for i in [1..(inp.Length) - 1] do yield nums.[i] - nums.[i - 1]] |>
          List.filter (fun i -> i > 0) |>
          List.length

printfn "%i" res