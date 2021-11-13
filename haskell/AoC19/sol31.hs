import Data.List

main = do  
    contents <- readFile "inp31l"
    let w1 = split ',' contents

    contents <- readFile "inp31r"
    let w2 = split ',' contents

    let w1g = build_g_list (0,0) w1 []
    let w2g = build_g_list (0,0) w2 []

    let intersections = [(w1g!!a, w2g!!b) | a <- [0..length w1g - 1], b <- [0..length w2g - 1], intersects (w1g!!a) (w2g!!b) && not (a == 0 && b == 0)]

    let c = map coord intersections

    let dist = map plus c

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

plus :: (Int, Int) -> Int
plus c = abs (fst c) + abs (snd c)