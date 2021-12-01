let inp = Seq.toList (System.IO.File.ReadLines("fsharp/AoC2021/1/input1.txt")) 
let nums = List.map int inp

let res = [ for i in [2..nums.Length-1] do 
            yield 
              nums.[i - 2] + nums.[i - 1] + nums.[i]] |>
          (fun lst -> List.zip (List.tail lst) lst.[0..lst.Length - 2]) |>
          List.map (fun (a, b) -> a - b) |>
          List.filter (fun i -> i > 0) |>
          List.length
          
printfn "%i" res