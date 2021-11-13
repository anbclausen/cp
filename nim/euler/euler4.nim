func palindrome(s: string): bool =
  let len = s.len
  let n = len div 2
  for i in 0..<n:
    if s[i] != s[len - 1 - i]:
      return false
  return true

var largest = 0
for i in 100..999:
  for j in 100..999:
    let prod = i * j
    if palindrome($prod):
      largest = max(largest, prod)

echo largest