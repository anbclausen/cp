import sequtils, math, sugar

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

proc divisors(n: int): int =
  var m = n
  var i = 0
  var res = repeat(1, 10000)
  while m > 1:
    let p = primes[i]
    if m mod p == 0:
      m = m div p
      inc res[i]
    else: 
      inc i
  return res.prod()

var triangle = toSeq(1..n)

for i in 1..<len(triangle):
  triangle[i] += triangle[i - 1]

for t in triangle:
  let d = divisors(t)
  if d >= 500:
    echo t
    break