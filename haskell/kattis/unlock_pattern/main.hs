import Data.List ( elemIndex )

distance :: (Int, Int) -> (Int, Int) -> Float
distance (x, y) (x', y') = 
  sqrt $ fromIntegral ((x - x') ^ 2 + (y - y') ^ 2)

index :: Int -> [Int] -> (Int, Int)
index s li = (i `mod` 3, i `div` 3)
  where 
    Just i = elemIndex s li

main :: IO()
main = do 
  content <- getContents
  let elems = map read $ words content
  print $ foldl (\acc e -> acc + distance (index e elems) (index (e + 1) elems)) 0 [1..8]