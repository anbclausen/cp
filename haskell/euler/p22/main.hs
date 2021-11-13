import Data.List

score :: Char -> Int 
score c = i
  where 
    zipped = zip ['A'..'Z'] [1..]
    Just (_, i) = find (\(c', i') -> c' == c) zipped

main :: IO ()
main = do 
  content <- readFile  "p022_names.txt"
  let names = words [if x == ',' then ' ' else x | x <- content, x /= '"']
  let sorted_names = sort names
  let indexed = zip sorted_names [1..]
  let res = foldl (\acc (n, i) -> acc + i * sum (map score n)) 0 indexed
  print res