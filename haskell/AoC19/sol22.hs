import Data.List
import Data.Sequence
import Data.Foldable

main = do  
    contents <- readFile "inp21"
    let list = map read $ split ',' contents :: [Int]
    --opList (upList (upList list 1 12) 2 2) 0

    let solutions = [ (n,v) | n <- [0..99], v <- [0..99], (run n v)!!0 == 19690720]
    print (solutions)

split :: Char -> [Char] -> [[Char]]
split c l = map tail (groupBy (\a b -> b /= c) (tail l))

upList :: [Int] -> Int -> Int -> [Int]
upList list i v = Data.Foldable.foldr (:) [] (update i v $ fromList list)

opList :: [Int] -> Int -> [Int]
opList list i 
    | list!!i == 1  = opList (upList list (list!!(i + 3)) (list!!(list!!(i + 1)) + list!!(list!!(i + 2)))) (i + 4)
    | list!!i == 2  = opList (upList list (list!!(i + 3)) (list!!(list!!(i + 1)) * list!!(list!!(i + 2)))) (i + 4)
    | otherwise     = list
    
run :: Int -> Int -> [Int]
run n v = opList [1,n,v,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,5,23,1,9,23,27,2,27,6,31,1,5,31,35,2,9,35,39,2,6,39,43,2,43,13,47,2,13,47,51,1,10,51,55,1,9,55,59,1,6,59,63,2,63,9,67,1,67,6,71,1,71,13,75,1,6,75,79,1,9,79,83,2,9,83,87,1,87,6,91,1,91,13,95,2,6,95,99,1,10,99,103,2,103,9,107,1,6,107,111,1,10,111,115,2,6,115,119,1,5,119,123,1,123,13,127,1,127,5,131,1,6,131,135,2,135,13,139,1,139,2,143,1,143,10,0,99,2,0,14,0] 0