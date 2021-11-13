main = do  
    contents <- readFile "inp11"
    let list = map readInt . words $ contents
    
    let fuel = map calc list
    print (sum fuel)


readInt :: String -> Int
readInt = read

calcFuel :: Int -> Int
calcFuel n = div n 3 - 2

calcRecFuel :: Int -> Int
calcRecFuel n
    | calcFuel n <= 0   = n
    | otherwise         = n + calcRecFuel (calcFuel n)

calc :: Int -> Int
calc n = calcRecFuel n - n