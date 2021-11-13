import math, sequtils, sugar

func isPrime(n: int64): bool =
  let roof: int = sqrt(n.float).ceil().int
  if n == 2:
    return true
  for i in 2..roof:
    if n mod i == 0:
      return false
  return true

const n = 2000000
let primes = toSeq(2..n).filter(n => isPrime(n))

echo primes.sum()