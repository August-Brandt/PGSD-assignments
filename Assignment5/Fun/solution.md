# Exercise 5.1 (Implement merge in F# and Java)
The function **merge** is implemented separately using F# and Java (**merge.fs** and **merge.java**, respectively). 

# Exercise 5.7 (Extend the monomorphic type checker to deal with lists)
TODO...

# Exercise 6.1 (Download/unpack fun1.zip, fun2.zip. Build the micro-ML higher-order evaluator)
3 does indeed run as expected because the value of `x` in the closure for the function `addtwo` is set to the value we gave `x` when defining `addtwo` to be `add 2` thusly the `let x = 77` does not change the value within the confines of the function `addtwo` I HEREBY DECLARE!!!!

The reason that 4 gives us a closure is that we call `add` with one arguments setting the `x` variable in the environment. The body of `add` is the function of `f` which is all we get back because we then don't call f with any arguments. 

# Exercise 6.2 (Add anonymous functions)
**eval** can now evaluate such anonymous functions.

# Exercise 6.3 (Extend the micro-ML lexer and parser specifications to permit anonymous functions)
Done.

# Exercise 6.4

# Exercise 6.5
## Part 1:
```
let f x = 1
in f f end
```
Types to `int`


Expressions not typable`

```
let f g = g g
in f end
```
Is ill typed because of the finite non circular rule of polymorphism. Since g calls g we get a circular loop = bad

```
let f x =
    let g y = y
    in g false end
in f 42 end
```
Types to `bool` 

```
let f x =
    let g y = if true then y else x
    in g false end
in f 42 end
```
Is ill typed because  
> "A type parameter that is used in an enclosing scope cannot be generalized"

meaning that x and y would have to be the same type since otherwise would have two different return types. In this case y is a bool and x is an int which makes no sense.

```
let f x =
    let g y = if true then y else x
    in g false end
in f true end
```
Types to `bool`

## Part 2:

`bool -> bool`
```
let f x = if x then x else x in f true end
```  
Types to `bool` = success

`int -> int`

```
let f x = x in f 1 end
```
Types to `int` = success

`int -> int -> int`

```
let f x = 
    let g y = x+y 
    in g 2 end
in f 4 end
```
Types to `int` might be fine idk

`'a -> 'b -> 'a`

```
let f x = 
    let g y = x
    in g true end
in f 2 end 
```