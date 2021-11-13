import math, sequtils, sugar

const phi: float64 = (1 + sqrt(5.0))/2.0
const psi: float64 = (1 - sqrt(5.0))/2.0

func fib(n: int): int = 
  ((pow(phi, n.float64) - pow(psi, n.float64)) / sqrt(5.0)).int

let sum = toSeq(1..100).map(n => fib(n))
                       .filter(n => n < 4000000 and n mod 2 == 0)
                       .sum()

echo sum