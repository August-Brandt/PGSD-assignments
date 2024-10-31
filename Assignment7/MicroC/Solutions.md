# 8.1
    Ex3
    ```
    [LDARGS; CALL (1, "L1"); STOP; < main(int n) call with command-line args>
   Label "L1";
    INCSP 1; < declare int i >
    GETBP; CSTI 1; ADD; < Put i address on stack >
    CSTI 0; STI; INCSP -1; < initialize i = 0 >
    GOTO "L3"; < start while loop >
   Label "L2"; 
    GETBP; CSTI 1; ADD; LDI; < Load variable i >
    PRINTI; INCSP -1; < print i > 
    GETBP; CSTI 1; ADD; < Put i address on stack >
    GETBP; CSTI 1; ADD; < Put i address on stack>
    LDI; CSTI 1; ADD; STI; INCSP -1; < i = i + 1 >
    INCSP 0; < block end (move local vars out of scope) >
   Label "L3": 
    GETBP; CSTI 1; ADD; LDI; < Load variable i >
    GETBP; CSTI 0; ADD; LDI; < Load variable n >
    LT; IFNZRO "L2"; INCSP -1; RET 0 < while loop check ( if i < n )>
    ]
    ```

    Ex5
    ```
    [LDARGS; CALL (1, "L1"); STOP;  < main(int n) call with command-line args>
   Label "L1";
    INCSP 1; < declare r (int r) >
    GETBP; CSTI 1; ADD; < put r address on stack >
    GETBP; CSTI 0; ADD; LDI; < put n value on stack >
    STI; INCSP -1; < Store n value into r >
    < start of internal block ({) >
    INCSP 1; < declare local scope r >
    GETBP; CSTI 0; ADD; LDI; < put n value on stack >
    GETBP; CSTI 2; ADD; < put local r address on stack>
    CALL (2, "L2"); INCSP -1; < call to square(n, &r) with void return >
    GETBP; CSTI 2; ADD; LDI; < put r value on stack >
    PRINTI; INCSP -1; < print r >
    INCSP -1; < exit local scope (put local vars out of scope) >
    < end of internal block (}) >
    GETBP; CSTI 1; ADD; LDI; < put r value on stack>
    PRINTI; INCSP -1; < print r >
    INCSP -1; RET 0; < return from main() with void and put local vars out of scope >
   Label "L2"; 
    GETBP; CSTI 1; ADD; LDI; < put value of rp on stack (address of r from main) >
    GETBP; CSTI 0; ADD; LDI; < put value of i on stack (n value from main)>
    GETBP; CSTI 0; ADD; LDI; < put value of i on stack (n value from main)>
    MUL; STI; INCSP -1; < *rp = i * i >
    INCSP 0; RET 1 < exit call scope and return void >
    ]
    ```

    Java trace:
    Look at the temp file gl hf :salute:
    HELP ;(
<br>
# 8.3 
See Comp.fs at `and cExpr` at line 165
Example program is ex83.c

# 8.4 
    ex8.c:
    ```
    [
    LDARGS; CALL (0, "L1"); STOP; 
Label "L1"; 
    INCSP 1; GETBP; CSTI 0; ADD;
    CSTI 20000000; STI; INCSP -1; GOTO "L3"; 
Label "L2"; 
    GETBP; CSTI 0; ADD;
    GETBP; CSTI 0; ADD; LDI; CSTI 1; SUB; STI; INCSP -1; INCSP 0; 
Label "L3";
    GETBP; CSTI 0; ADD; LDI; IFNZRO "L2"; INCSP -1; RET -1
    ]
    ```
    prog1:
    ```
    0: CSTI 20000000;
    2: GOTO 7;
    4: CSTI 1;
    6: SUB;
    7: DUP;
    8: IFNZRO 4
    10: STOP;
    ```

`ex8.c` has significantly more instructions than `prog1`, which makes it slower 

```
[
    LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
    CSTI 1889; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; GETBP;
    CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 1; ADD; LDI;
    CSTI 4; MOD; CSTI 0; EQ; IFZERO "L7"; GETBP; CSTI 1; ADD; LDI; CSTI 100;
    MOD; CSTI 0; EQ; NOT; IFNZRO "L9"; GETBP; CSTI 1; ADD; LDI; CSTI 400; MOD;
    CSTI 0; EQ; GOTO "L8"; Label "L9"; CSTI 1; Label "L8"; GOTO "L6";
    Label "L7"; CSTI 0; Label "L6"; IFZERO "L4"; GETBP; CSTI 1; ADD; LDI;
    PRINTI; INCSP -1; GOTO "L5"; Label "L4"; INCSP 0; Label "L5"; INCSP 0;
    Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
    IFNZRO "L2"; INCSP -1; RET 0
]
```

The loop will have to evaluate the conditional from scratch for each iteration. That is kinda slow when some values could be carried over from previous evaluation.

