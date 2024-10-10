# Solution for exercises
## 7.1
```
Prog
    [Fundec (None, "main", [(TypI, "n")], <- The declaration of the "main" function, return type none, name "main", arguments 1 integer into n
        Block [ <- start of the body of the "main" function
                Stmt (While
                        (Prim2 (">", Access (AccVar "n"), CstI 0), <- Make a "while" statement that checks is "n > 0"
                Block [ <- start of body of while statement
                        Stmt (Expr (Prim1 ("printi", Accss (AccVar "n")))); <- print the value of variable n
                            Stmt (Expr (Assign
                                        (AccVar "n",
                                        Prim2 ("-", Access (AccVar "n"), CstI 1)))) <- assign the result of n -1 to n
                        ]));
                Stmt (Expr (Prim1 ("printc", CstI 10)))]) <- Statement that prints a newline
              ]
```
Trust me bro. We ran the interpreter on the ex1 and ex11 programs :\/ Kaj out here

## 7.2
(i) -> ex721.c
(ii) -> ex722.c
(iii) -> ex723.c

## 7.3
Done
You can find an example of a forloop in the file `exFor.c`

## 7.4
Done
Solution can be found at the top of the `eval` function in `Interp.fs`

## 7.5 
Check the lexer and parser files
Example can be found in `exIncDec.c`