main = interact $ output . solve . tail . map read . words

solve :: [Int] -> Maybe Int
solve [] = Just 0
solve [x] = Nothing
solve (x:y:xs) = plus (Just (y - x)) (solve xs)

plus :: Maybe Int -> Maybe Int -> Maybe Int
plus (Just n) (Just m) = Just (n + m)
plus _ _ = Nothing

output :: Show a => Maybe a -> String 
output (Just n) = show n
output _ = "still running"