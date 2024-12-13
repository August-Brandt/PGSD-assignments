// 11.1

// Old stinky version ew 
let rec len xs =
    match xs with
    | [] -> 0
    | x::xr -> 1 + len xr


// Better not stinky version yum (continuation)
let rec lenc lst con = 
    match lst with
    | [] -> con 0
    | _::xs -> lenc xs (fun i -> con (i+1))
    
// it works its not stinky
let a1 = lenc [2; 5; 7] id

lenc [2; 5; 7] (printf "The answer is ’% d’ \n")

// Different better not stinky version yum (tail recursive)
let rec leni lst acc =
    match lst with
    | [] -> acc
    | _::xs -> leni xs (acc+1)

let a2 = leni [2; 5; 7] 0


// 11.2

// Old stinky version ew 
let rec rev xs =
    match xs with
    | [] -> []
    | x::xr -> rev xr @ [x]

// It reverses with minus stink rizz on them lists yo
let rec revc lst (con : ('a list -> 'a list)) =
    match lst with
    | [] -> con []
    | x::xs -> revc xs (fun r -> x :: con r)

let b1 = revc [1; 2; 3] id
let b2 = revc [1;2;3;4] (fun v -> v @ v)

// It reverses with the tail of a non stinky function
let rec revi lst acc =
    match lst with
    | [] -> acc
    | x::xs -> revi xs (x :: acc)

let b3 = revi [1;2;3] []


// 11.3

// Prod function with some extra stinky
let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x * prod xr

// we continuing to eliminate the stinky ew ew
let rec prodc lst con = 
    match lst with
    | [] -> con 1
    | x::xs -> prodc xs (fun r -> (con r) * x)

let c1 = prodc [1;2;3] id

// 11.4
let rec bprodc lst con = 
    match lst with
    | [] -> con 1
    | x::xs when x = 0 -> 0
    | x::xs -> bprodc xs (fun r -> (con r) * x)

let d1 = bprodc [1;2;0;44] id

// This of course gives an error since its int -> int lol
// let d2 = bprodc [1;2;3] (printf "The answer is ’% d’ \n")

let rec prodi lst acc =
    match lst with
    | [] -> acc
    | x::xs when x = 0 -> 0
    | x::xs -> prodi xs (acc * x)


let d3 = prodi [1; 2; 0; 44] 0