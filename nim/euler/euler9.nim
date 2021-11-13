const top = 1000

block loop:
  for i in 1..top:
    for j in 1..top:
      for k in 1..top:
        if i + j + k == top and i*i + j*j == k*k:
          echo i*j*k
          break loop