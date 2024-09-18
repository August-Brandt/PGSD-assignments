# 3.3
let z = (17) in z + 2 * 3 end EOF

```
Main (A)=> 
Expr EOF (F)=> 
LET NAME EQ Expr IN Expr END EOF(G)=> 
LET NAME EQ Expr IN Expr TIMES Expr END EOF (C)=> 
LET NAME EQ Expr IN Expr TIMES CSTINT END EOF (H) => 
LET NAME EQ Expr IN Expr PLUS Expr TIMES CSTINT END EOF (C)=> 
LET NAME EQ Expr IN Expr PLUS CSTINT TIMES CSTINT END EOF (B)=> 
LET NAME EQ Expr IN NAME PLUS CSTINT TIMES CSTINT END EOF (E)=> 
LET NAME EQ LPAR Expr RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF (C)=> 
LET NAME EQ LPAR CSTINT RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF
```

# 3.4
![tree](./imgs/tree.png)

# 3.5 
Done it worked after some trial and error. Had to remove microsoft from a few opens and remove the lexing part of the open statement in Parse.fs
```
$ dotnet fsi -r ~/Documents/ITU/5._Semester/ProgramsAsData/ProgramsAsDataCodeE2024/fsharp/FsLexYacc.Runtime.dll Absyn.fs ExprPar.fs ExprLex.fs Parse.fs
```

# 3.6
You can find this function inside Parse.fs it now also opens Expr as we need the scomp function from there
