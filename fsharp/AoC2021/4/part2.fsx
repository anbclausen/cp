let inp = Seq.toList (System.IO.File.ReadLines "fsharp/AoC2021/4/input.txt")
let numbers = Array.map int (inp.[0].Split ',')
let boards_inp = List.tail inp
let boards = 
  [for i in [0..6..boards_inp.Length - 1] do 
    yield array2D (List.foldBack (fun (e: string) acc -> 
      [for j in [0..3..14] do (* 14 chars in a line *)
        yield int (e.Substring (j, 2))] :: acc) (boards_inp[i+1..i+5]) [])] (* 5 rows in a board *)

let diff list1 list2 =
  List.fold (fun acc e -> List.filter ((<>) e) acc) list1 list2

let did_board_win (board: int[,]) (nums: list<int>) =
  let mutable won = false
  for i in [0..4] do (* 5 columns and 5 rows *)
    (* did we win on a colmumn or row? *)
    if diff (Array.toList board.[*, i]) nums = [] || diff (Array.toList board.[i, *]) nums = [] then 
      won <- true
  won

let mutable already_won = Set.ofList []
let mutable last_won = -1

let simulate_winnings nums = 
  for i in [0..boards.Length-1] do 
    let board = boards.[i]
    if did_board_win board nums then 
      if not (already_won.Contains i) then 
        already_won <- already_won.Add i
        last_won <- i

let board_sum (board: int[,]) nums =
  let board_list = 
    [ 
      let height = board.GetLength 0
      for row in 0..height-1 do
        yield board.[row,*] |> List.ofArray
    ]
  List.fold (fun acc e -> List.sum (diff e nums) + acc) 0 board_list

let mutable last_winning_nums = []

for i in [0..numbers.Length-1] do 
  let nums = List.ofArray numbers[0..i]
  simulate_winnings nums
  if already_won.Count = boards.Length && last_winning_nums = [] then 
    last_winning_nums <- nums
  
printfn "%i" (board_sum (boards.[last_won]) last_winning_nums * last_winning_nums.[last_winning_nums.Length-1])
