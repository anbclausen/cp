import Data.List

main = do  
    contents <- readFile "inp31l"
    let w1 = split ',' contents

    contents <- readFile "inp31r"
    let w2 = split ',' contents

    let w1g = build_g_list (0,0) w1 []
    let w2g = build_g_list (0,0) w2 []

    let intersecs = intersections w1g w2g

    let c = map coord intersecs

    let dist = [totalSteps w1g w2g (intersecs!!a) (c!!a)| a <- [0..length intersecs - 1]]

    print (minimum dist)

split :: Char -> [Char] -> [[Char]]
split c l = map tail (groupBy (\a b -> b /= c) l)

graph :: (Int, Int) -> [Char] -> ((Int, Int),(Int, Int))
graph from s
    | head s == 'R' = (from, (fst from, snd from + (read (tail s) :: Int)))
    | head s == 'U' = (from, (fst from + (read (tail s) :: Int), snd from))
    | head s == 'L' = (from, (fst from, snd from - (read (tail s) :: Int)))
    | head s == 'D' = (from, (fst from - (read (tail s) :: Int), snd from))


build_g_list :: (Int, Int) -> [[Char]] -> [((Int, Int),(Int, Int))] -> [((Int, Int),(Int, Int))]
build_g_list from list g_list
    | null list = g_list
    | otherwise = build_g_list (snd (graph from (head list))) (tail list) (g_list ++ [(graph from (head list))])

intersects :: ((Int, Int),(Int, Int)) -> ((Int, Int),(Int, Int)) -> Bool
intersects a b
    | between (fst (fst a)) (fst (fst b)) (fst (snd a)) && between (snd (snd b)) (snd (fst a)) (snd (fst b)) = True
    | between (fst (fst b)) (fst (fst a)) (fst (snd b)) && between (snd (snd a)) (snd (fst b)) (snd (fst a)) = True
    | otherwise = False

between :: Int -> Int -> Int -> Bool
between a b c
    | a <= b && b <= c  = True
    | c <= b && b <= a  = True
    | otherwise         = False

coord :: (((Int, Int), (Int, Int)),((Int, Int), (Int, Int))) -> (Int, Int)
coord cross
    | fst (fst (fst cross)) == fst (snd (fst cross))    = (fst (fst (fst cross)), snd (snd (snd cross)))
    | otherwise                                         = (fst (snd (snd cross)), snd (fst (fst cross)))

len :: ((Int, Int), (Int, Int)) -> Int
len line = abs ((fst (fst line)) - (fst (snd line))) + abs ((snd (fst line)) - (snd (snd line)))

steps :: ((Int, Int), (Int, Int)) -> [((Int, Int),(Int, Int))] -> (Int, Int) -> Int
steps line list coord
    | line == head list && isHor line   = len line - (abs (fst (snd line) - fst coord))
    | line == head list                 = len line - (abs (snd (snd line) - snd coord))
    | otherwise                         = (len (head list)) + steps line (tail list) coord

rest :: ((Int, Int), (Int, Int)) -> (Int, Int) -> Int
rest line coord
    | fst (fst line) == fst (snd line)  = abs ((snd coord) - snd (fst line))
    | otherwise                         = abs ((fst coord) - fst (fst line))

totalSteps:: [((Int, Int),(Int, Int))] -> [((Int, Int),(Int, Int))] -> (((Int, Int), (Int, Int)),((Int, Int), (Int, Int))) -> (Int, Int) ->  Int
totalSteps w1 w2 intersection coord = (steps (fst intersection) w1 coord) + (steps (snd intersection) w2 coord)

isHor :: ((Int, Int), (Int, Int)) -> Bool
isHor line
    | snd (fst line) == snd (snd line)  = True
    | otherwise                         = False

intersections :: [((Int, Int),(Int, Int))] -> [((Int, Int),(Int, Int))] -> [(((Int, Int), (Int, Int)),((Int, Int), (Int, Int)))]
intersections w1g w2g = [(w1g!!a, w2g!!b) | a <- [0..length w1g - 1], b <- [0..length w2g - 1], intersects (w1g!!a) (w2g!!b) && not (a == 0 && b == 0)]