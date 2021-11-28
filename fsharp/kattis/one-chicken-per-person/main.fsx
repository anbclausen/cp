open System
let res = Console.ReadLine().Split(' ')   |>
          Seq.map (fun s -> int s)        |>
          Seq.toList                      |>
          (fun l -> l.[1] - l.[0])

if res < 0 then 
  let s = if res = -1 then "more piece" else "more pieces"
  printfn "Dr. Chaz needs %i %s of chicken!" (abs res) s
else 
  let s = if res = 1 then "piece" else "pieces"
  printfn "Dr. Chaz will have %i %s of chicken left over!" res s