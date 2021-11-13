func collatz(n: int): int =
  if n mod 2 == 0:
    n div 2
  else:
    3 * n + 1

proc steps(n: int): int =
  var m = n
  while m != 1:
    m = collatz(m)
    inc result
  result + 1

var res = (0, 0)
for i in 1 ..< 1000000:
  let s = steps(i)
  if res[0] < s:
    res = (s, i)

echo res