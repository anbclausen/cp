import math, sequtils, sugar

func isPrime(n: int64): bool =
  let roof: int = sqrt(n.float).ceil().int
  if n == 2:
    return true
  for i in 2..roof:
    if n mod i == 0:
      return false
  return true

let primes = toSeq(2..100000).filter(n => isPrime(n))

var x = 600851475143
var largePrime = 2

for p in primes:
  if x == 1:
    break
  while x mod p == 0:
    largePrime = p
    x = x div p

echo largePrime