import math

var squares = 0
var sum = 0
for i in 1..100:
  squares += i^2
  sum += i

echo $(sum^2 - squares)