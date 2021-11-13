main = do
  _ <- getLine
  inp <- getLine
  let nums = map read . words $ inp
  let filtered = [n :: Float | n <- nums, n /= -1]
  let res = sum filtered / fromIntegral (length filtered)
  print res