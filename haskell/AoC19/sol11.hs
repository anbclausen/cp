main = do  
    contents <- readFile "inp11"
    let list = map readInt . words $ contents
    
    let fuel = map calcFuel list
    print (sum fuel)


readInt :: String -> Int
readInt = read

calcFuel :: Int -> Int
calcFuel n = div n 3 - 2