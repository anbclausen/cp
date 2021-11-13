import math, sequtils, sugar

func isPrime(n: int64): bool =
  let roof: int = sqrt(n.float).ceil().int
  if n == 2:
    return true
  for i in 2..roof:
    if n mod i == 0:
      return false
  return true

let primes = toSeq(2..1000000).filter(n => isPrime(n))

echo primes[10000]