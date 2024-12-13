# Assignment 10

## 11.1

*i* 
It done. See `./Cont/JustBetter.fs`

*ii*
It returns double the length so for 3 items it returns 6

*iii*
It too returns 3 so it sure does work
The two new functions both avoid storing unneeded stack-frames during the recursive calls

## 11.2

*i*
It done. See `./Cont/JustBetter.fs`

*ii*
With our implementation of revc calling with `fun v -> v @ v` results in the same output
This is because the base case will just run [] @ [] and then do the rest of the continuation 

*iii*

## 11.3
See the code in the `./Cont/JustBetter.fs` file it works fine

## 11.4
See code in `./Cont/JustBetter.fs`

We can't call the `prodc` (or `bprodc`) with the continuation: `(printf "The answer is ’% d’ \n")` since it has the wrong type:
It should be `int->int` which is what the exercise says the type for the continuation should be and `(printf "The answer is ’% d’ \n")` has type `int -> unit`

prodi does the do

## 11.8

*i*
Every(Write(Prim("+", CstI 1, Prim("*", CstI 2, FromTo(1, 4)))))
Writes:
3 5 7 9

Every(Write(Prim("+", Prim("*", CstI 10, FromTo(2, 4)), FromTo(1, 2))))
Writes:
21 22 31 32 41 42

*ii*
Write(Prim("<", CstI 50, Prim("*", CstI 7, FromTo(1, 50))))
Writes:
56