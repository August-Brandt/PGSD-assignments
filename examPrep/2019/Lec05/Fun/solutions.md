# 2

## 2.1
```
let x = { } in x end (* ex1 *)
let x = {field1 = 32} in x.field1 end (* ex2 *)
let x = {field1 = 32; field2 = 33} in x end (* ex3 *)
let x = {field1 = 32; field2 = 33} in x.field1 end (* ex4 *)
let x = {field1 = 32; field2 = 33} in x.field1+x.field2 end (* ex5 *)
```

```
ex1: Let ("x",Record [], Var "x")
ex2: Let ("x",Record [("field1", CstI 32)],Field (Var "x","field1"))
ex3: Let ("x", Record [("field1", CstI 32); ("field2", CstI 33)], Var "x")
ex4: Let ("x", Record [("field1", CstI 32); ("field2", CstI 33)], Field (Var "x","field1"))
ex5: Let ("x", Record [("field1", CstI 32); ("field2", CstI 33)], Prim("+",Field (Var "x","field1"), Field (Var "x", "field2")))
```

## 2.2

