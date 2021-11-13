func divisible(n: int): bool = 
  for i in 2..20:
    if n mod i != 0:
      return false
  return true

var n = 2520
while not divisible(n):
  n += 1

echo $n