open ParseAndRunHigher;;
//fromString "let s1 = {2, 3} in let s2 = {1, 4} in s1 ++ s2 = {2,4,3,1} end end";;
run (fromString "let s1 = {2, 3} in let s2 = {1, 4} in s1 ++ s2 = {2,4,3,1} end end");;
printfn "%A" it;;
//run (fromString "let s1 = {2, 3} in let s2 = {1, 4} in s1 ++ s2 = {2,4,3,1} end end");;