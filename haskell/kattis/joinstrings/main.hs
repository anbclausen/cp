import Data.Array ( (!), listArray, Array )
import qualified Data.Text.IO as TIO
import qualified Data.Text as T
import Data.IORef ( IORef, newIORef, readIORef, writeIORef )
import Data.List ( foldl' )

data LinkedList a =
    E a (IORef (LinkedList a)) (IORef (LinkedList a))
  | Empty

new :: a -> IO (LinkedList a)
new e = do
  nextref <- newIORef Empty
  lastref <- newIORef Empty
  return $ E e nextref lastref

llconcat :: LinkedList T.Text -> LinkedList T.Text -> IO ()
llconcat (E e nextref lastref) (E ne nnextref nlastref) = do
  last <- readIORef lastref
  case last of
    E le lnext _ -> writeIORef lnext (E ne nnextref nlastref)
    Empty -> writeIORef nextref (E ne nnextref nlastref)
  nlast <- readIORef nlastref
  case nlast of
    Empty -> writeIORef lastref (E ne nnextref nlastref)
    _ -> writeIORef lastref nlast
llconcat (E e nextref lastref) Empty = do
  return ()
llconcat Empty _ = error "Cannot append to empty LinkedList"

next :: LinkedList a -> IO (LinkedList a)
next (E e ref _) = do
  readIORef ref
next Empty = error "Cannot take next of empty LinkedList"

printLinkedList :: LinkedList T.Text -> IO ()
printLinkedList (E s n p) = do
  TIO.putStr s
  n <- next (E s n p)
  printLinkedList n
printLinkedList Empty = do putStr "\n"

toUnlinkedList :: [a] -> IO [LinkedList a]
toUnlinkedList (x : xs) = do
  ll <- new x
  rest <- toUnlinkedList xs
  return $ ll : rest
toUnlinkedList [] = return []

stringToPair :: T.Text -> (Int, Int)
stringToPair s = (a, b)
  where
    a : b : _ = map read . words . T.unpack $ s

eval :: Array Int (LinkedList T.Text) -> [(Int, Int)] -> IO Int
eval arr = inner
  where
    inner :: [(Int, Int)] -> IO Int
    inner ((f, t) : rest) = do
      let from = arr ! f
      let to = arr ! t
      llconcat from to
      if null rest then
        return f
      else
        eval arr rest
    inner [] = error "Cannot evaluate empty ops list"

main :: IO ()
main = do
  content <- TIO.getContents
  let n : rst = T.lines content
  let i = read $ T.unpack n
  let (strings, ops) = splitAt i rst
  case i of
    1 -> TIO.putStrLn $ head strings
    _ -> do
      unlinkedStrings <- toUnlinkedList strings
      let strarr = listArray (1, i) unlinkedStrings
      let intOps = map stringToPair ops
      last <- eval strarr intOps
      printLinkedList (strarr ! last)