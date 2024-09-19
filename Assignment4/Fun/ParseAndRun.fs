(* File Fun/ParseAndRun.fs *)

module ParseAndRun

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;

let e42_1 = run (fromString "let f x = if x = 0 then 0 else x + f (x-1) 
                                in f 1000 end")
let e42_2 = run(fromString "let f x = if x = 1 then 3 else 3 * f (x-1) 
                                in f 8 end")
let e42_3 = run(fromString "let pow y = if y = 0 then 1 else 3 * pow (y-1) 
                                in let sum x = if x = 12 then 0 else pow (x) + sum (x+1) 
                                    in sum 0
                                end
                            end")
// shit works take that mark zuckerberg
let test = run(fromString "let sum x = if x = 0 then 0 else x * x * x * x * x * x * x * x + sum (x-1)
                                in sum 10
                            end")