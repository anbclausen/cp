dominant :: Char  -> Char -> Bool 
dominant c c' = c == c'

value :: Char -> Bool -> Int
value 'A' _ = 11
value 'K' _ = 4
value 'Q' _ = 3
value 'J' True = 20
value 'J' False = 2
value 'T' _ = 10
value '9' True = 14
value _ _ = 0

main :: IO ()
main = do 
  line <- getLine
  let _ : (dom : _) : _ = words line
  let isDom = dominant dom
  inp <- getContents 
  let res = foldl (\acc (n:s:_) -> value n (isDom s) + acc) 0 (words inp)
  print res
