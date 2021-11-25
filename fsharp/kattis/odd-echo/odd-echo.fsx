open System 

let n = int (Console.ReadLine())
for i in 0 .. n do
  let inp = Console.ReadLine()
  if i % 2 = 0 then 
    printfn "%s" inp 
