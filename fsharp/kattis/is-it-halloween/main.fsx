open System 

let inp = Console.ReadLine()
printfn "%s"  (if inp = "OCT 31" || inp = "DEC 25" then
                "yup"
              else 
                "nope")
