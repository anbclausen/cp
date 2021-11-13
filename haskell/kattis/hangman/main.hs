remove :: Eq a => [a] -> a -> [a]
remove s c = [x | x <- s, x /= c] 

solve :: (Eq t, Num t) => [Char] -> [Char] -> t -> [Char]
solve "" _  _ = ""
solve word _ 0 = word
solve word perm lives = 
  if word == res then solve word t (lives - 1) else solve res t lives
  where 
    c : t = perm
    res = remove word c

main :: IO ()
main = do
  word <- getLine
  perm <- getLine
  let res = solve word perm 10
  case res of 
    "" -> putStrLn "WIN"
    _  -> putStrLn "LOSE"