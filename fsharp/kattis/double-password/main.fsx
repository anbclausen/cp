open System 

let pw1 = Console.ReadLine()
let pw2 = Console.ReadLine()

let exponent = Seq.fold (fun acc e -> acc + if fst e = snd e then 0 else 1) 0 (Seq.zip pw1 pw2)

printfn "%i" (pown 2 exponent)